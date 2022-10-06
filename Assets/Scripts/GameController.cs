using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int curTime;
    int m_curTime;

    int m_rightAnswerCount;
    // Start is called before the first frame update
    void Start()
    {
        CreateQuestion();
        m_curTime = curTime;
        UIManager.Ins.SetTimeText(SetText(m_curTime));
        StartCoroutine(TimCountingDown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateQuestion()
    {
        QuestionData qs = QuestionManager.Ins.GetRandomQuestion();

        if (qs != null)
        {
            UIManager.Ins.SetQuestionText(qs.question);
            string[] wrongAnswers = new string[] { qs.answerA, qs.answerB, qs.answerC };

            UIManager.Ins.ShuffleAnswer();
            var temp = UIManager.Ins.answerButtons;


            if(temp!=null&& temp.Length > 0)
            {
                int wrongAnswerCount = 0;
                for(int i = 0; i < temp.Length; i++)
                {
                    int answerID = i;
                    if (string.Compare(temp[i].tag, "RightAnswer") == 0)
                    {
                        temp[i].SetAnswerText(qs.rightAnswer);
                    }
                    else
                    {
                        temp[i].SetAnswerText(wrongAnswers[wrongAnswerCount]);
                        wrongAnswerCount++;
                    }

                    temp[answerID].btnComp.onClick.RemoveAllListeners();
                    temp[answerID].btnComp.onClick.AddListener(() => CheckRightAnswerEvent(temp[answerID]));
                }
            }

        }
    }
    void CheckRightAnswerEvent(AnswerButton answerButton)
    {
        if (answerButton.CompareTag("RightAnswer"))
        {
            if (m_rightAnswerCount == QuestionManager.Ins.questions.Length-1)
            {
                AudioController.Ins.PlayWinSound();
                UIManager.Ins.dialog.SetDialogContentText("Ban da chien thang!");
                UIManager.Ins.dialog.IsShow(true);
                StopAllCoroutines();
            }
            else
            {
                AudioController.Ins.PlayRightSound();
                m_curTime = curTime;
                UIManager.Ins.SetTimeText(SetText(m_curTime));
                m_rightAnswerCount++;
                CreateQuestion();
            }
        }
        else
        {
            AudioController.Ins.PlayLoseSound();
            UIManager.Ins.dialog.SetDialogContentText("Ban da chon sai. Tro choi ket thuc!");
            UIManager.Ins.dialog.IsShow(true);
            StopAllCoroutines();
        }
    }

    IEnumerator TimCountingDown()
    {
        yield return new WaitForSeconds(1);
        if (m_curTime > 0)
        {
            m_curTime--;
            UIManager.Ins.SetTimeText(SetText(m_curTime));
            StartCoroutine(TimCountingDown());
        }
        else
        {
            UIManager.Ins.dialog.SetDialogContentText("Da het thoi gian. Tro choi ket thuc!");
            UIManager.Ins.dialog.IsShow(true);
        }
    }
    public void Replay()
    {
        SceneManager.LoadScene("Gameplay");
    }
    public void Exit()
    {
        Application.Quit();
    }

    string SetText(int time)
    {
        string txt;

        if (time >= 600)
        {
            txt = "" + time / 60 + ":" + time % 60;
        }
        else if (time >= 10)
        {
            txt = "00:" + time;
        }
        else
        {
            txt = "00:0" + time;
        }
        return txt;
    }
}
