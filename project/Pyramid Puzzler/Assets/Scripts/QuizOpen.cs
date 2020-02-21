using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizOpen : MonoBehaviour
{
    public static bool quizOpen = false;

    public GameObject quizUI;
    // Update is called once per frame
    
    void Update()
    {
        // Replace  with stepping on tiles later on
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Just for testing
            if (quizOpen)
                Resume();
            // This is the important one
            else
                Quiz();
        }
    }

    // Again, just for testing
    // This will actually be done in a quiz class later on
    void Resume()
    {
        quizUI.SetActive(false);
        Time.timeScale = 1f;
        quizOpen = false;
    }

    void Quiz()
    {
        quizUI.SetActive(true);
        Time.timeScale = 0f;
        quizOpen = true;
    }
}
