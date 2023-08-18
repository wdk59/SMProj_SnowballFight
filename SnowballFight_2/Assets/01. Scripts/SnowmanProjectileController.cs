using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanProjectileController : MonoBehaviour
{

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("������� �����̸� ����!");
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.forward * 2500.0f);
    }
    void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("�ǰ� �Ɽ");
            //Instantiate(crashSoundPrefab, position, rotation);
            
        }
        else
        {
            Debug.Log("����!");
            Destroy(gameObject);
        }
    }
}
