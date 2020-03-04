using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]

    Text scoreText = null;

    private int score = 0;


    // Start is called before the first frame update
    public void SetScore()
    {
        if(scoreText)
            scoreText.text = score.ToString();
    }

    public void ScoreUP()
    {
       score += 10;
    }

    // Update is called once per frame

}
