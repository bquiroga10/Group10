using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizOpen : MonoBehaviour
{
    private static QuizOpen instance = null;
    public static bool quizOpen = false;

    public GameObject quizUI;

    // Update is called once per frame

    void Update()
    {
        // Replace  with stepping on tiles later on
        if ((Input.GetKeyDown(KeyCode.Q) && !quizOpen))
        {
            instance = this;
            Quiz();
        }
    }

    public static QuizOpen GetInstance()
    {
        return instance;
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

    public void Answer(AnswerButton selection)
    {
        if (selection.isCorrect)
            Correct();
        else
            Incorrect();
    }

    public void Correct()
    {
        Debug.Log("Correct!");
        Resume();

    }

    // When lives are implemented, it will also subtract a life
    public void Incorrect()
    {
        Debug.Log("Incorrect");
    }
}
