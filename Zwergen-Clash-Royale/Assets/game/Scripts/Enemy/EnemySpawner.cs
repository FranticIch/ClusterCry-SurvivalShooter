using CompleteProject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public float reSpawnTime = 30;
    public GameObject enemyPrefab;
    public bool NightSpawner;
	
    private float deathTime;
	private bool alive = false;
	
    void Start() {
		deathTime = 0;
	}

    void Update() {
		if(Time.time > deathTime + reSpawnTime){
			Spawn();
		}
	}

    void Spawn() {
        if (NightSpawner)
        {
            if (!FindObjectOfType<DayNightManager>().night)
                return;
        }

		if(reSpawnTime <= 0 || alive)
			return;
		
        GameObject enemy = Instantiate(enemyPrefab, transform.position, transform.rotation) as GameObject;
        enemy.GetComponent<EnemyMovement>().SetSpawner(this);
		enemy.GetComponent<EnemyHealth>().SetSpawner(this);
		alive = true;
	}
	
	public void SetDead() {
		deathTime = Time.time;
		alive = false;
	}
}
