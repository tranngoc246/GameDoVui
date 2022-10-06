using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI dialogContentText;

    public void IsShow(bool isShow)
    {
        gameObject.SetActive(isShow);
    }

    public void SetDialogContentText(string txt)
    {
        if (dialogContentText)
        {
            dialogContentText.text = txt;
        }
    }
}
