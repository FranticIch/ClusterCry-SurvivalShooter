using CompleteProject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GnomSpawner : MonoBehaviour {

    public float spawntime = 30f;
    public GameObject enemy;
    public bool isInRange = false;
    public bool isDead = false;
    public float spawnTimer = 30f;

    public GameObject gnom;
    float timer = 0f;

    // Use this for initialization
    void Start()
    {
        gnom = Spawn();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!gnom && gnom.GetComponent<EnemyHealth>().isDead)
        {
            isDead = true;

        }

        if(isDead)
        {
            timer += Time.deltaTime;
        }
        
        if(timer >= spawnTimer)
        {
            Spawn();
            timer = 0f;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
            if (!gnom && !gnom.GetComponent<EnemyHealth>().isDead)
                gnom.GetComponent<EnemyMovement>().RangeTrigger();
                
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
            if (!gnom && !gnom.GetComponent<EnemyHealth>().isDead)
                gnom.GetComponent<EnemyMovement>().RangeTrigger();

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
            if (!gnom && !gnom.GetComponent<EnemyHealth>().isDead)
                gnom.GetComponent<EnemyMovement>().NotRangeTrigger();

        }
    }

    GameObject Spawn() {
        gnom = Instantiate(enemy, transform.position, transform.rotation);
        return gnom;
    }
}
