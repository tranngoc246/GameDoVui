using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    public TextMeshProUGUI answerText;
    public Button btnComp;

    public void SetAnswerText(string txt)
    {
        if (answerText)
        {
            answerText.text = txt;
        }
    }
}
