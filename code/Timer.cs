using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]

    Text timerText = null;

    public int timeLeft = 15;

    public bool running = false;

    public IEnumerator SetTimer()
    {
        tText();
        while (running == false && timeLeft > 0)
        {
            running = true;
            yield return new WaitForSeconds(1);
            timeLeft--;
            // Include game over feature if timer hits 0 here
            running = false;
        }
    }

    public void tText()
    {
      timerText.text = timeLeft.ToString();
    }
}
