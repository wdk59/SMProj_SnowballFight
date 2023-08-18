using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private short playerHP;
    
    private void Awake()
    {
        playerHP = 3;
    }

    public short showPlayerHP()
    {
        return playerHP;
    }

    public short losePlayerHP()
    {
        return --playerHP;
    }
}
