using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CompleteProject;

public class BulletExplosion : MonoBehaviour {

    public float damage = 20f;
    
    private float maxLifeTime = 3f;
    ParticleSystem hitParticles;
    // Use this for initialization
    void Start () {
        hitParticles = getComponentInChildren<ParticleSystem>; 
        Destroy(gameObject, maxLifeTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
