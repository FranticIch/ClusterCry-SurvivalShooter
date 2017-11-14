using CompleteProject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrenade : MonoBehaviour {

    public LayerMask enemyMask;
    //public ParticleSystem explosionParticles;
    
    public float maxDamage = 100f;
    public float explosionForce = 1000f;
    public float maxLifeTime = 3f;
    public float explosionRadius = 2f;
    
    ParticleSystem explosionParticles;
    public AudioSource explosionAudio;

    // Use this for initialization
    void Start()
    {
        explosionParticles = GetComponentInChildren<ParticleSystem>();
        Destroy(gameObject, maxLifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("CombatDectector"))
        {

            Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, enemyMask);

            for (int i = 0; i < colliders.Length; i++)
            {
           
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
               

                }

            }


            // Unparent the particles from the shell.
            explosionParticles.transform.parent = null;

            // Play the particle system.
            explosionParticles.Play();

            //explosionAudio.transform.parent = null;
            explosionAudio.gameObject.transform.parent = null;
            explosionAudio.Play();
            Destroy(explosionAudio.gameObject, explosionAudio.clip.length);

           
            //AUDIO HERE


            // Once the particles have finished, destroy the gameobject they are on.
            ParticleSystem.MainModule mainModule = explosionParticles.main;
            Destroy(explosionParticles.gameObject, mainModule.duration);

            // Destroy the shell.
        
            Destroy(gameObject);
        }
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

