using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private short playerHP;

    private short currentStage;

    [SerializeField]
    private GameObject[] playerHPIcon = new GameObject[5];
    
    private void Awake()
    {
        playerHP = 5;
        currentStage = 1;
    }

    private void Initialize()
    {
        playerHP = 5;
        // ��Ʈ UI �׸���
        currentStage = 1;
    }

    public short showPlayerHP()
    {
        return playerHP;
    }

    public short losePlayerHP()
    {
        playerHP -= 1;
        // Heart UI ����
        return playerHP;
    }

    public short showStage()
    {
        return currentStage;
    }
}
