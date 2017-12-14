using CompleteProject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightEnemy : MonoBehaviour {
    EnemyHealth enemyHealth;
	// Use this for initialization
	void Start () {
        enemyHealth = GetComponent<EnemyHealth>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!FindObjectOfType<DayNightManager>().isNight)
        {
            enemyHealth.TakeDamage(500, enemyHealth.gameObject.transform.position);
        }
	}
}
