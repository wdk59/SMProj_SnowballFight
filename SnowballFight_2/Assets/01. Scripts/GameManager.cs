using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private short playerHP;
    public bool isPaused;

    public short currentStage;

    [SerializeField]
    private GameObject[] playerHPIcon = new GameObject[5];
    
    private void Awake()
    {
        playerHP = 5;
        isPaused = false;
        currentStage = 1;
    }

    private void Initialize()
    {
        playerHP = 5;
        // 하트 UI 그리기
        currentStage = 1;
    }

    public void StageUp()
    {
        playerHP = 5;
        for (int i = 0; i < 5; i++)
        {
            playerHPIcon[i].SetActive(true);
        }
    }

    public short showPlayerHP()
    {
        return playerHP;
    }

    public short losePlayerHP()
    {
        if (playerHP > 0)
        {
            playerHP -= 1;
            Debug.Log("playerHP: " + playerHP);
            playerHPIcon[playerHP].SetActive(false);
        }

        return playerHP;
    }

    public short showStage()
    {
        return currentStage;
    }

    public void stageUI()
    {
        
    }
}
