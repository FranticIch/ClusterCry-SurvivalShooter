using CompleteProject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrenade : MonoBehaviour {

    public LayerMask enemyMask;
    //public ParticleSystem explosionParticles;
    // public AudioSource explosionAudio;
    public float maxDamage = 100f;
    public float explosionForce = 1000f;
    public float maxLifeTime = 3f;
    public float explosionRadius = 2f;

    GameObject player;
    PlayerShooting ps;
    ParticleSystem explosionParticles;

    // Use this for initialization
    void Start()
    {
        explosionParticles = GetComponentInChildren<ParticleSystem>();
        Destroy(gameObject, maxLifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, enemyMask);

        for (int i = 0; i < colliders.Length; i++)
        {
           

            Debug.Log(colliders[i].tag);

            if (colliders[i].CompareTag("Enemy"))
            {

                Rigidbody targetRididbody = colliders[i].GetComponent<Rigidbody>();

                if (!targetRididbody)
                {
                    continue;
                }

                targetRididbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);

                EnemyHealth targetHealth = targetRididbody.GetComponent<EnemyHealth>();

                if (!targetHealth)
                {
                    continue;
                }
                
                int damage = CalculateDamage(targetRididbody.position);
                
                targetHealth.TakeDamage(damage, targetRididbody.position);

                Debug.Log("Target Health after: " + targetHealth.currentHealth);

            }

        }


        // Unparent the particles from the shell.
        explosionParticles.transform.parent = null;

        // Play the particle system.
        explosionParticles.Play();

      /*  // Play the explosion sound effect.
        m_ExplosionAudio.Play(); */

          // Once the particles have finished, destroy the gameobject they are on.
        ParticleSystem.MainModule mainModule = explosionParticles.main;
        Destroy(explosionParticles.gameObject, mainModule.duration);

        // Destroy the shell.
        Destroy(gameObject);
    }

    private int CalculateDamage(Vector3 targetPosition)
    {
        Vector3 explosionToTarget = targetPosition - transform.position;

        float explosionDistance = explosionToTarget.magnitude;

        float relativeDistance = (explosionRadius - explosionDistance) / explosionRadius;

        float damage = relativeDistance * maxDamage;

        damage = Mathf.Max(0f, damage);

        return (int)damage;
    }
}

