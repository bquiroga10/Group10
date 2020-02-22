using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    public bool isCorrect = false;

    public void Select()
    {
        QuizOpen.GetInstance().Answer(this);
    }
}
