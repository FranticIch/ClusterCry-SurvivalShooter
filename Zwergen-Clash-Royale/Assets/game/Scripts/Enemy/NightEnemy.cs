using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CompleteProject;

public class NightEnemy : MonoBehaviour {
    private GameObject enemyHealth;
	// Use this for initialization
	void Start () {
        enemyHealth = FindObjectOfType<EnemyHealth>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!FindObjectOfType<DayNightManager>().night)
        {
            enemyHealth.Damage(100);
        }
	}
}
