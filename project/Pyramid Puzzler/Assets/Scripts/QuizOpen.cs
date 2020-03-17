using System;
using System.Collections.Generic;
using UnityEngine;

using OpenTDB;

public class QuizOpen : MonoBehaviour
{
    private static QuizOpen instance = null;

    [SerializeField]

    private QuestionRequest api = null;

    [SerializeField]

    private QuestionCanvas canvas = null;

    [SerializeField]

    private ScoreManager sm = null;

    [SerializeField]

    private Timer tm = null;


    private List<Question> question;

    public static bool quizOpen = false;

    public GameObject quizUI;

    public static bool busy = false;

    // Update is called once per frame

    void Update()
    {
        // Replace  with stepping on tiles later on
        if (GridManager.requestQuestion && !quizOpen)
        {
            busy = true;
            GridManager.requestQuestion = false;

            if (api) // Checks if the api is present.
            {
                api.MakeRequest(
                    new Action<Response>((Response response) =>
                    { 
                        question = response.results;
                        Quiz();
                    })
                    );
            }
            else
            {

            }
            instance = this;

        }
        if (quizOpen == true)
        {
            StartCoroutine(tm.SetTimer());
        }
    }

    public static QuizOpen GetInstance()
    {
        return instance;
    }

    // Again, just for testing
    // This will actually be done in a quiz class later on
    public void Resume()
    {
        quizUI.SetActive(false);
        quizOpen = false;
    }

    public void Quiz()
    {
        quizUI.SetActive(true);
        quizOpen = true;
        Question q = question[0];
        if (canvas)
        {
            canvas.SetQuestion(q, tm);
        }
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
        sm.ScoreUP(question[0].difficulty);
        sm.SetScore();
        tm.timeLeft = 15;
        Resume();
        busy = false;
    }

    // When lives are implemented, it will also subtract a life
    public void Incorrect()
    {
        Debug.Log("Incorrect");
    }

}
