using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanProjectileController : MonoBehaviour
{

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("´«»ç¶÷ÀÌ ´«µ¢ÀÌ¸¦ ´øÁü!");
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.forward * 2500.0f);
    }
    void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("ÇÇ°Ý Äâ±¤");
            //Instantiate(crashSoundPrefab, position, rotation);
            
        }
        else
        {
            Debug.Log("ÇÇÇÔ!");
            Destroy(gameObject);
        }
    }
}
