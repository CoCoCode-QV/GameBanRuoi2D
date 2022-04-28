using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    Text m_ScoreText;

    [SerializeField]
    GameObject GameOverPane;

    public void SetScoreText(string txt)
    {
        if (m_ScoreText)
        {
            m_ScoreText.text = txt;

        }
    }
    public void ShowGameOverPane(bool isShow)
    {
        if (GameOverPane)
        {
            GameOverPane.SetActive(isShow);
        }
    }
}
