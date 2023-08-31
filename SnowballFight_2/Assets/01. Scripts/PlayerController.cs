using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager gm;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SnowmanProjectile")
        {
            if (gm.losePlayerHP() <= 0)
            {
                OnDie();    // Invoke�� ���� �ֱ�
            }
        }
    }

    private void OnDie()
    {
        Debug.Log("�׾���");
        Application.Quit();
    }

    private void Initialize()
    {

    }
}
