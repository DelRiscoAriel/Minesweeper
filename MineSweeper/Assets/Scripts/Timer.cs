using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    int time = 60;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Time");
    }

    // Update is called once per frame
    void Update()
    {
        text.text = ("Time Remaining: " + time);

        if (time == 0)
            SceneManager.LoadScene("Lose1");
    }

    IEnumerator Time()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            time--;
        }
    }
}
