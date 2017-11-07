using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CompleteProject;

public class BulletExplosion : MonoBehaviour {

    public int damage = 50;
    
    private float maxLifeTime = 3f;
    ParticleSystem hitParticles;

    void Start () {
        hitParticles = GetComponentInChildren<ParticleSystem>(); 
        Destroy(gameObject, maxLifeTime);

        hitParticles.transform.parent = null;
        hitParticles.Play();

        ParticleSystem.MainModule mainModule = hitParticles.main;
        Destroy(hitParticles.gameObject, mainModule.duration);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth targetHealth = other.GetComponent<EnemyHealth>();
            targetHealth.TakeDamage(damage, transform.position);
        }

        Destroy(gameObject);
    }
}
