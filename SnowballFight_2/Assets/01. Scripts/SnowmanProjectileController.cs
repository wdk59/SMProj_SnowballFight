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
        rb.AddRelativeForce(Vector3.forward * 2500.0f); // �̰� �۵��� �� �ϴ� ��
    }
    void OnCollisionEnter(Collision collision)
    {
        //ContactPoint contact = collision.contacts[0];

        Debug.Log("������� ���� ��: " + collision.gameObject.tag);

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("�ǰ� �Ɽ");
            //Instantiate(crashSoundPrefab, position, rotation);
            
        }
        else if (collision.gameObject.tag != "Snowman")
        {
            Debug.Log("����!");
            Destroy(gameObject);
        }
    }
}
