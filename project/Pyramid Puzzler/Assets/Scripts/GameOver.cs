using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    private QuizOpen open = null;

    public void GameEnd()
    {
        QuizOpen.GetInstance().Resume();
        SceneManager.LoadScene("GameOver");
    }
}
