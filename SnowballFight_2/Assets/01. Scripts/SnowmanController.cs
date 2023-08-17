using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanController : MonoBehaviour
{
    private short snowmanHP;

    public GameObject snowmanProjectile;
    public Transform firePos;
    private float attackDelay;

    void Awake()
    {
        snowmanHP = 5;
        attackDelay = 1.0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
        StartCoroutine("AttackDelay");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Initialize()
    {
        snowmanHP = 100;
        attackDelay = 1.0f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Snowball")
        {
            LoseHP(20);
        }
    }

    private void LoseHP(short damage)
    {
        snowmanHP -= damage;
        if (snowmanHP <= 0) { OnDie(); }
    }
    public short LookSnowmanHP()
    {
        return snowmanHP;
    }

    private void OnDie()
    {
        StopCoroutine("AttackDelay");
        Debug.Log("Stage Clear!");
        Destroy(gameObject);
    }

    IEnumerator AttackDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackDelay);
            OnFire();
        }
    }
    private void OnFire()
    {
        Debug.Log("户具户具 " + snowmanProjectile.name);
    }
}
