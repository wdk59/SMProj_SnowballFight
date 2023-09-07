using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameManager gm;

    public GameObject stageInfoPanel;
    [SerializeField]
    private GameObject snowman;
    [SerializeField]
    private Text snowmanInfoValue;
    [SerializeField]
    private GameObject currentStageIcon;
    [SerializeField]
    private Transform[] stageIconPos = new Transform[3];

    private void Start()
    {
        StartStageInfo(5, 2.5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SnowmanProjectile")
        {
            if (gm.losePlayerHP() <= 0)
            {
                Debug.Log("Áê±Ý ½ÃÀñ");
                Time.timeScale = 1;
                Invoke("OnDie", 1f);
            }
        }
    }

    public void StartStageInfo(short snowmanHP, float snowmanFrequency) // stage upgrade
    {
        Debug.Log("StartStageInfo");
        gm.isPaused = true;
        currentStageIcon.transform.position = stageIconPos[gm.currentStage - 1].position;
        snowmanInfoValue.text = snowmanHP + "\n" + snowmanFrequency;
        stageInfoPanel.SetActive(true);
        snowman.SetActive(false);
        gm.StageUp();
        Invoke("ExitStageInfo", 3f);
    }
    private void ExitStageInfo()
    {
        Debug.Log("ExitStageInfo");
        stageInfoPanel.SetActive(false);
        gm.isPaused = false;
        snowman.SetActive(true);
        snowman.GetComponent<SnowmanController>().Initialize();
    }

    private void OnDie()
    {
        Debug.Log("Á×¾ú´ç");
        //Application.Quit();
        SceneManager.LoadScene("Lobby");
    }

    private void Initialize()
    {

    }
}
