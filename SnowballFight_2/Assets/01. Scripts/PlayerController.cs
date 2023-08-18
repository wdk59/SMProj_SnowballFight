using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager gm;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Snowman")
        {
            if (gm.losePlayerHP() <= 0)
            {
                Debug.Log("ав╬З╢Г");
                Application.Quit();
            }
        }
    }
}
