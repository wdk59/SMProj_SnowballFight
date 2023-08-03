using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatingSnowball : MonoBehaviour
{

    public void CreateSnowball() {
        Debug.Log("CreateSnowball");
    }

    private void OnCollisionExit(Collision collision)
    {
        //CreateSnowball();
    }
}
