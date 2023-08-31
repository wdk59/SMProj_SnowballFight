using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnEvents : MonoBehaviour
{
    public void OnStartBtn()
    {
        Debug.Log("���� ����");
        SceneManager.LoadScene("SnowballFight");
    }

    public void OnQuitBtn()
    {
        Debug.Log("���� ����");
        Application.Quit();
    }

    public void OnPauseBtn()
    {
        Debug.Log("�Ͻ� ���� Ȱ��ȭ");
        Time.timeScale = 0;
    }

    public void OnResumeBtn()
    {
        Debug.Log("�Ͻ� ���� ��Ȱ��ȭ");
        Time.timeScale = 1;
    }
}
