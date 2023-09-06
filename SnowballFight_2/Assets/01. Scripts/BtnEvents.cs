using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnEvents : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer sptRenderer;
    [SerializeField]
    private Sprite pauseBtnIcon;
    [SerializeField]
    private Sprite resumeBtnIcon;

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
        GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        Debug.Log("������Ʈ �̸�: " + gameObject.name);
        if (!gm.isPaused)
        {
            Debug.Log("�Ͻ� ���� Ȱ��ȭ");
            sptRenderer.sprite = resumeBtnIcon;
            Time.timeScale = 0;
            gm.isPaused = true;
        } else if (gm.showPlayerHP() > 0)
        {
            Debug.Log("�Ͻ� ���� ��Ȱ��ȭ");
            sptRenderer.sprite = pauseBtnIcon;
            Time.timeScale = 1;
            gm.isPaused = false;
        }
    }

    public void OnResumeBtn()
    {
        Debug.Log("�Ͻ� ���� ��Ȱ��ȭ");
        Time.timeScale = 1;
    }
}
