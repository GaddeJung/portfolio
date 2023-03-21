using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeEffect : MonoBehaviour
{

    public string targetMsg;
    public GameObject endCursor;
    public int CharPErSeconds;
    Text msgText;
    int index;

    private void Awake()
    {
        msgText= GetComponent<Text>();
    }

    public void SetMsg(string msg)
    {
        targetMsg = msg;
        EffectStart();

    }

    void EffectStart()
    {
        endCursor.SetActive(false);
        msgText.text = "";
        index = 0;

        Invoke("Effecting", 1/ CharPErSeconds);
    }

    void Effecting()
    {
        if (msgText.text == targetMsg)
        {
            EffectEnd();
            return;
        }
        msgText.text += targetMsg[index];
        index++;

        Invoke("Effecting", 1 / CharPErSeconds);
    }

    void EffectEnd()
    {
        endCursor.SetActive(true);
    }

}
