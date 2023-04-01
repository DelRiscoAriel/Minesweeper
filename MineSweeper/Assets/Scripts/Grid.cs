using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public static int w = 10;
    public static int h = 13;
    public static Element[,] elements = new Element[w, h];

    //Method to uncoverd the mines
    public static void uncoverdMines()
    {
        foreach (Element elem in elements)
        {
            if (elem.mine)
                elem.loadTexture(0);
        }
    }

    //Method to tell if a mine is at a certain XY coordinate
    public static bool mineAt(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < w && y < h)
            return elements[x, y].mine;

         return false;
    }

    //Method to count adjacent mines from elements
    public static int adjacentMines(int x, int y)
    {
        int count = 0;

        if (mineAt(x, y + 1))
            ++count;
        if (mineAt(x + 1, y + 1))
            ++count;
        if (mineAt(x + 1, y))
            ++count;
        if (mineAt(x + 1, y - 1))
            ++count;
        if (mineAt(x, y - 1))
            ++count;
        if (mineAt(x - 1, y - 1))
            ++count;
        if (mineAt(x - 1, y))
            ++count;
        if (mineAt(x - 1, y + 1))
            ++count;

        return count;
    }

    //Method to flood fill adjacent elemnts
    public static void FFuncover(int x , int y, bool[,] visited)
    {
        if(x >= 0 && y >= 0 && x < w && y < h)
        {
            if (visited[x, y])
                return; //If visted exit

            //Unciver the element
            elements[x, y].loadTexture(adjacentMines(x, y));

            //Check if we are close to a mine so we can stop uncoveting
            if (adjacentMines(x, y) > 0)
                return;

            //It was not visited so we set a flag for it now being visited
            visited[x, y] = true;

            //Recursion for the other directions from the initial elemnt. Spread
            FFuncover(x - 1, y, visited);
            FFuncover(x + 1, y, visited);
            FFuncover(x, y - 1, visited);
            FFuncover(x, y + 1, visited);
        }
    }

    //Method to check if the grid has been cleared wiyhout any mines being touch
    public static bool isFinished()
    {
        foreach (Element elem in elements)
            if (elem.isCovered() && !elem.mine)
                return false;

        return true;
    }
}
