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
        Initialize();
        StartCoroutine("AttackDelay");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Initialize()
    {
        snowmanHP = snowmanStageHP[gm.currentStage - 1];
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
        if (snowmanHP <= 0) {
            gm.isPaused = true;
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
        StageUp();
        if (gm.currentStage == 3)
        {
            // 텍스트 띄워놓기 (눈사람은 패배를 인정하고 봄을 돌려주기로 했고, 결국 녹아 없어졌다. 사람들은 이 일을 계기로 환경을 복구하기 위해 노력하게 되었다.)
            Invoke("StageClear", 2f);
        }
        else
        {
            player.gameObject.GetComponent<PlayerController>().StartStageInfo(snowmanStageHP[gm.currentStage - 1], attackDelay[gm.currentStage - 1]);
        }
    }

    private void StageClear()
    {
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

        Debug.Log("빵야빵야 " + snowmanProjectile.name);
        Instantiate(snowmanProjectile, firePos.transform.position, rot);

    }
}
