using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class QuestionRequest : MonoBehaviour
{
    [SerializeField]
    private string url = "https://opentdb.com/api.php?amount=1";

    private IEnumerator Request()
    {
        UnityWebRequest req = UnityWebRequest.Get(url);
        yield return req.SendWebRequest();


    }

    public static string ToText(byte[] bytes)
    {
        return System.Text.Encoding.Default.GetString(bytes);
    }
}
