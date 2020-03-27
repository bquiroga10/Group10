using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUps : MonoBehaviour
{
    // Start is called before the first frame update


    private Health h = null;
    private QuestionCanvas canvas = null;
    private int first;
    private int second;
    private bool sqIsActive = false;
    public bool eiIsActive = false;

    [SerializeField]
    Button pUp1;

    /*
    public void HealthPlus()
    {
        h.health++;   
    }


    public void EliminateIncorrect()
    {
        eiIsActive = true;
    }
    */

    public void UseSQ()
    {
        QuizOpen.GetInstance().Resume();
        pUp1.gameObject.SetActive(false);
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

void Update()
    {
        // Use for testing
        Debug.Log(sqIsActive);
        if (Input.GetKeyDown(KeyCode.L))
        {
            pUp1.gameObject.SetActive(true);
            Debug.Log("hello");
        }
    }
}
