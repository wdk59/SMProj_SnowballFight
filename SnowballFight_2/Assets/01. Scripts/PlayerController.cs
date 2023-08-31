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
                OnDie();    // Invoke로 지연 주기
            }
        }
    }

    private void OnDie()
    {
        Debug.Log("죽었당");
        Application.Quit();
    }

    private void Initialize()
    {

    }
}
