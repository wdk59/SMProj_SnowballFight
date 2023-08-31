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

    public void OnPauseBtn()
    {
        Debug.Log("일시 정지 활성화");
        Time.timeScale = 0;
    }

    public void OnResumeBtn()
    {
        Debug.Log("일시 정지 비활성화");
        Time.timeScale = 1;
    }
}
