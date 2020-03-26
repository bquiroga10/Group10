using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    // Start is called before the first frame update
    private Health h = null;
    private QuestionCanvas canvas = null;
    private QuizOpen open = null;
    private int first;
    private int second;

    public bool sqIsActive = false;
    public bool eiIsActive = false;

    public void HealthPlus()
    {
        h.health++;   
    }

    public void SkipQuestion()
    {
        sqIsActive = true;
    }

    public void EliminateIncorrect()
    {
        eiIsActive = true;
    }

    public void UseSQ()
    {
        open.Resume();
        sqIsActive = false;
    }

    // Update is called once per frame
    /*
    public void UseEI()
    {
        select2();
        canvas.incorrectAnswers[first].setActive(false);
        eiIsActive = false;
    }

    private void Select2()
    {
        first = Random.Range(0, 2);
        second = Random.Range(0, 1);
        if (first == 0 || (first == 1 & second == 1))
            second++;
    }
    */

    // Use for testing
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
            SkipQuestion();
    }
}
