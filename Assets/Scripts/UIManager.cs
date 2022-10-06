using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Ins;

    public TextMeshProUGUI questionText;
    public TextMeshProUGUI timeText;
    public Dialog dialog;

    public AnswerButton[] answerButtons;

    private void Awake()
    {
        MakeSingleton();
    }

    public void SetQuestionText(string txt)
    {
        if (questionText)
        {
            questionText.text = txt;
        }
    }
    public void SetTimeText(string txt)
    {
        if (timeText)
        {
            timeText.text = txt;
        }
    }

    public void ShuffleAnswer()
    {
        if (answerButtons!=null && answerButtons.Length > 0)
        {
            for(int i = 0; i < answerButtons.Length; i++)
            {
                answerButtons[i].tag = "Untagged";
            }
            int randIdx = Random.Range(0, answerButtons.Length);
            answerButtons[randIdx].tag = "RightAnswer";
        }
    }

    public void MakeSingleton()
    {
        if (Ins == null)
        {
            Ins = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
