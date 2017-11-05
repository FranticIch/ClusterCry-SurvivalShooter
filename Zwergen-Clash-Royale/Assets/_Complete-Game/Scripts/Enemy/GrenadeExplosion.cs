using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeExplosion : MonoBehaviour
{

    public LayerMask m_enemyMask;
    //public ParticleSystem explosionParticles;
   // public AudioSource explosionAudio;
    public float maxDamage = 100f;
    public float explosionForce = 1000f;
    public float maxLifeTime = 5f;
    public float explosionRadius = 5f;

    List<GameObject> targets = new List<GameObject> { };
    //public EnemyHealth enemyHealth;



    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, maxLifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, m_enemyMask);
        
        Debug.Log("Collider Length: " + colliders.Length);

        

        for (int i = 0; i< colliders.Length; i++)
        {

            Debug.Log("Collider Name: " + colliders[i].name);

            Debug.Log(colliders[i].tag);

            if(colliders[i].CompareTag("Enemy"))
            {
                targets.Add(colliders[i].gameObject);
                
            }

        }

            for(int i = 0; i< targets.Count; i++)
            {
                Debug.Log("Target Name: " + targets[i].name);


                targets[i].GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRadius);

                EnemyHealth targetHealth = GameObject.Find(targets[i].name).GetComponent<EnemyHealth>();

                //EnemyHealth targetHealth = targets[i].GetComponent<Rigidbody>().GetComponent<EnemyHealth>();

                if (!targetHealth)
                {
                    Debug.Log("Target Health is null");
                    continue;
                }

                Debug.Log("Target Health before: " + targetHealth.currentHealth);

                int damage = CalculateDamage(targets[i].GetComponent<Rigidbody>().position);

                Debug.Log("Calculated Damage: " + damage);

                targetHealth.TakeDamage(damage, targets[i].GetComponent<Rigidbody>().position);

                Debug.Log("Target Health after: " + targetHealth.currentHealth);
            }
            
      



        /*  // Unparent the particles from the shell.
          m_ExplosionParticles.transform.parent = null;

          // Play the particle system.
          m_ExplosionParticles.Play();

          // Play the explosion sound effect.
          m_ExplosionAudio.Play();

          // Once the particles have finished, destroy the gameobject they are on.
          ParticleSystem.MainModule mainModule = m_ExplosionParticles.main;
          Destroy(m_ExplosionParticles.gameObject, mainModule.duration); */

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

        return (int) damage;
    }
}
