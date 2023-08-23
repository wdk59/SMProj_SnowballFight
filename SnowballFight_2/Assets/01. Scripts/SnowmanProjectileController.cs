using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanProjectileController : MonoBehaviour
{

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("눈사람이 눈덩이를 던짐!");
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.forward * 2500.0f); // 이게 작동을 안 하는 중
    }
    void OnCollisionEnter(Collision collision)
    {
        //ContactPoint contact = collision.contacts[0];

        Debug.Log("눈사람이 던진 곳: " + collision.gameObject.tag);

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("피격 콰광");
            //Instantiate(crashSoundPrefab, position, rotation);
            
        }
        else if (collision.gameObject.tag != "Snowman")
        {
            Debug.Log("피함!");
            Destroy(gameObject);
        }
    }
}
