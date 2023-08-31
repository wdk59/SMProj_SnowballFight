using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballCollisionCheck : MonoBehaviour
{
    //public AudioClip crashSoundClip;
    public Transform crashSoundPrefab;

    void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];

        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 position = contact.point;

        if (collision.gameObject.tag == "Snowman")
        {
            Debug.Log("°ø°Ý Äâ±¤");
            Instantiate(crashSoundPrefab, position, rotation);
            //AudioSource.PlayClipAtPoint(crashSoundClip, position, 10);
        }

        if (collision.gameObject.tag != "Dummy" && collision.gameObject.tag != "Snowball" && collision.gameObject.tag != "SnowmanProjectile")
        {
            Debug.Log("°ø°Ý ¸ø ¸ÂÃã!");
            Destroy(gameObject);
        }
    }
}
