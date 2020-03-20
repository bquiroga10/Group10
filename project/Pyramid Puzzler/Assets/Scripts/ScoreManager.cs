using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0;
    
    [SerializeField]

    Text scoreText = null;


    void Start() {
        score = 0;
    }

    public void SetScore()
    {
        if(scoreText)
            scoreText.text = score.ToString();
    }

    public void ScoreUP(string diff)
    {
        switch (diff)
        {
            case "easy":
                score += 10;
                break;

            case "medium":
                score += 20;
                break;

            case "hard":
                score += 30;
                break;
        }
    }
}
