using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField]

    Text timerText = null;

    private QuizOpen open = null;

    private GameOver gm = null;

    public int timeLeft = 15;

    public bool running = false;

    public bool active = false;

    public IEnumerator SetTimer()
    {
        tText();
        while ((running == false) && (active == true) && (timeLeft > 0))
        {
            running = true;
            yield return new WaitForSeconds(1);
            timeLeft--;
            if(timeLeft == 0)
            {
                QuizOpen.GetInstance().Resume();
                SceneManager.LoadScene("GameOver");
            }
            running = false;
        }
    }

    public void tText()
    {
      timerText.text = timeLeft.ToString();
    }

    public void ResetTimer()
    {
        timeLeft = 16;
    }

    private void Update()
    {
        active = QuizOpen.GetInstance().isOpen() ? true : false;
        StartCoroutine(SetTimer());
    }

}
