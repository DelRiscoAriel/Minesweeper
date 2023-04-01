using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour
{
    public bool mine;
    public Sprite[] emptyTexture;
    public Sprite mineTexture;

    void Start()
    {
        //Randomly decide if this is a mine or not
        mine = Random.value < 0.15;

        //Have this element reguiter itself into our grid
        int x = (int)transform.position.x;
        int y = (int)transform.position.y;
        Grid.elements[x, y] = this;
    }

    public void loadTexture(int adjancentCount)
    {
        if (mine)
            GetComponent<SpriteRenderer>().sprite = mineTexture;
        else
            GetComponent<SpriteRenderer>().sprite = emptyTexture[adjancentCount];
    }

    public bool isCovered()
    {
        return GetComponent<SpriteRenderer>().sprite.texture.name == "default";
    }

    void OnMouseUpAsButton()
    {
        if(mine)
        {
            //Uncover all the mines
            Grid.uncoverdMines();

            //Game Over
            Invoke("Lose", 0.5f);
            print("You lose");
        }

        //If this elemt is not a mine
        else
        {
            //Show adjacent mine number on this element as a texture
            int x = (int)transform.position.x;
            int y = (int)transform.position.y;
            loadTexture(Grid.adjacentMines(x, y));

            //Uncover area without mines
            Grid.FFuncover(x, y, new bool[Grid.w, Grid.h]);

            //Find if the game has been compleated
            if (Grid.isFinished())
                print("You Win");
        }
    }

    void Lose()
    {
        UI.Lose();
    }
}
