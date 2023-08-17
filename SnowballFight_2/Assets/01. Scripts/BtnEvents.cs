using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnEvents : MonoBehaviour
{
    public void OnStartBtn()
    {
        Debug.Log("게임 시작");
        SceneManager.LoadScene("SnowballFight");
    }

    public void OnQuitBtn()
    {
        Debug.Log("게임 종료");
        Application.Quit();
    }
}
