using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnowmanController : MonoBehaviour
{
    public GameManager gm;

    private short[] snowmanStageHP = new short[3] { 5, 7, 10 };         // snowman health
    private short snowmanHP;    // snowman current health

    public GameObject snowmanProjectile;
    public Transform firePos;
    private float[] attackDelay = new float[3] { 2.5f, 1.5f, 1.0f };    // snowman frequency

    public GameObject player;

    public Material[] mat = new Material[3];

    void Awake()
    {
        snowmanHP = snowmanStageHP[gm.currentStage - 1];
    }

    // Start is called before the first frame update
    void Start()
    {
        //Initialize();
    }

    public void Initialize()
    {
        Debug.Log("Snowman Initialize");
        snowmanHP = snowmanStageHP[gm.currentStage - 1];
        StartCoroutine("AttackDelay");
    }

    public void StageUp()
    {
        for (int i = 0; i <= 5; i++)
        {
            transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().material = mat[gm.currentStage - 1];
        }
        snowmanHP = snowmanStageHP[gm.currentStage - 1];
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Snowball" && !gm.isPaused)
        {
            LoseHP(1);
        }
    }

    private void LoseHP(short damage)
    {
        snowmanHP -= damage;
        Debug.Log("����� �ƾ�: " + snowmanHP);
        if (snowmanHP <= 0) {
            Invoke("OnDie", 2f);
        }
    }
    public short LookSnowmanHP()
    {
        return snowmanHP;
    }

    private void OnDie()
    {
        StopCoroutine("AttackDelay");
        Debug.Log("Stage Clear!");
        gm.currentStage++;
        Debug.Log("Stage Num: " + gm.currentStage);
        if (gm.currentStage > 3)
        {
            Debug.Log("2�� �� StageClear()");
            // �ؽ�Ʈ ������� (������� �й踦 �����ϰ� ���� �����ֱ�� �߰�, �ᱹ ��� ��������. ������� �� ���� ���� ȯ���� �����ϱ� ���� ����ϰ� �Ǿ���.)
            Invoke("StageClear", 2f);
        }
        else
        {
            StageUp();
            player.gameObject.GetComponent<PlayerController>().StartStageInfo(snowmanStageHP[gm.currentStage - 1], attackDelay[gm.currentStage - 1]);
        }
    }

    private void StageClear()
    {
        Debug.Log("StageClear()");
        SceneManager.LoadScene("Lobby");
    }

    IEnumerator AttackDelay()
    {
        while (true)
        {
            if (!gm.isPaused)
            {
                yield return new WaitForSeconds(attackDelay[gm.currentStage - 1]);
                OnFire();
            }
        }
    }
    private void OnFire()
    {
        Vector3 dir = player.transform.position - firePos.transform.position;
        Quaternion rot = Quaternion.LookRotation(dir).normalized;

        Debug.Log("���߻��� " + snowmanProjectile.name);
        Instantiate(snowmanProjectile, firePos.transform.position, rot);

    }
}
