using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplayer : MonoBehaviour
{
    [SerializeField]
    Text scoreText = null;
    // Start is called before the first frame update
    void Start() {
        if(scoreText)
            scoreText.text = "You finished the game with " + ScoreManager.score.ToString() + " points!";
    }
}
