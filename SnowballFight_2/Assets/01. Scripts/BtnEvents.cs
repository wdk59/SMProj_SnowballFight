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
        GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        Debug.Log("오브젝트 이름: " + gameObject.name);
        if (!gm.isPaused)
        {
            Debug.Log("일시 정지 활성화");
            sptRenderer.sprite = resumeBtnIcon;
            Time.timeScale = 0;
            gm.isPaused = true;
        } else if (gm.showPlayerHP() > 0)
        {
            Debug.Log("일시 정지 비활성화");
            sptRenderer.sprite = pauseBtnIcon;
            Time.timeScale = 1;
            gm.isPaused = false;
        }
    }

    public void OnResumeBtn()
    {
        Debug.Log("일시 정지 비활성화");
        Time.timeScale = 1;
    }
}
