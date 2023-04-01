using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Grid.isFinished())
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public static void Lose()
    {
        SceneManager.LoadScene("Lose1");
    }

    public static void Lose2()
    {
        SceneManager.LoadScene("Lose2");
    }

    public void Play1()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PLay2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
}
