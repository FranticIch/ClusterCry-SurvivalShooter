﻿using CompleteProject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageManager : MonoBehaviour {

    public Transform spawnPoint;
    public float spawntime = 30f;
    public GameObject enemy;
    public bool isInRange = false;

    List<GameObject> enemys = new List<GameObject> { };
    int count = 0;

    void Start () {
        InvokeRepeating("Spawn", 0f, 2f);
	}
	

	void FixedUpdate () {
		for(int i=0; i< enemys.Count; i++)
        {
            if (enemys[i].GetComponent<EnemyHealth>().isDead)
            {
                enemys.RemoveAt(i);
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
            if (enemys.Count > 0)
            {
                for (int i = 0; i < enemys.Count; i++)
                {
                    if (!enemys[i].GetComponent<EnemyHealth>().isDead)
                        enemys[i].GetComponent<EnemyMovement>().RangeTrigger();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (enemys.Count > 0)
            {
                for (int i = 0; i < enemys.Count; i++)
                {
                    if (!enemys[i].GetComponent<EnemyHealth>().isDead)
                        enemys[i].GetComponent<EnemyMovement>().NotRangeTrigger();
                }
            }
            
            isInRange = false;
        }
    }

    


    void Spawn()
    {
        if(enemys.Count<3)
        {
            enemys.Add(Instantiate(enemy, spawnPoint.position, spawnPoint.rotation));
            
        }

    }
    
}
