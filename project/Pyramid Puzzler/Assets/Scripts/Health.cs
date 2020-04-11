using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Health : MonoBehaviour
{
    public int numHearts = 3;
    public Image[] hearts;
    public Sprite redHeart;
    public Sprite blackHeart;

    public void loseHearts()
    {
        if (numHearts == 0)
        {
            PowerUps.sqIsActive = false;
            QuizOpen.GetInstance().Resume();
            SceneManager.LoadScene("GameOver");
        }
        numHearts--;
    }

    void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            Debug.Log(hearts.Length);
            if (i >= numHearts)
            {
                hearts[i].sprite = blackHeart;
            }
            else
            {
                hearts[i].sprite = redHeart;
            }
        }
    }
}