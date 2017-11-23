using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CompleteProject;

public class BulletExplosion : MonoBehaviour {

    public int damage = 50;
    public float explosionForce = 100f;
    
    private float maxLifeTime = 3f;
    private float explosionRadius = 0.5f;
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
            Rigidbody targetRigidbody = other.GetComponent<Rigidbody>();

            targetRigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);

            EnemyHealth targetHealth = other.GetComponent<EnemyHealth>();
            targetHealth.TakeDamage(damage, transform.position);
        }

        if (!other.gameObject.CompareTag("GoTrough"))
        {
            Destroy(gameObject);
        }
        
    }
}
