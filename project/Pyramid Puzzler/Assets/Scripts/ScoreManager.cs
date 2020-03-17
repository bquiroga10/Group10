using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]

    Text scoreText = null;

    public int score = 0;

    // Start is called before the first frame update
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
