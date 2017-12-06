using CompleteProject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCombat : MonoBehaviour {

    public int damage = 25;
    

    bool meleeAllowed;
    float meleeTimer;

    Animator anim;
    AudioSource punchAudio;

    private List<Rigidbody> enemysInRange = new List<Rigidbody> { };

    private void Awake()
    {
        meleeAllowed = true;
        anim = GetComponentInParent<Animator>();
        punchAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        meleeTimer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.F) && meleeAllowed)
        {
            meleeTimer = 0.0f;
            meleeAllowed = false;
           // playerMovement.SlowDownModificator = 0.75f;
            anim.SetTrigger("Attack");

        }

        if (meleeTimer >= 1.0f && !meleeAllowed)
        {
            attack();
            punchAudio.Play();
            meleeAllowed = true;

        }

        for (int i = 0; i < enemysInRange.Count; i++)
        {
            if (enemysInRange[i].GetComponent<EnemyHealth>().isDead)
            {
                enemysInRange.RemoveAt(i);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            enemysInRange.Add(other.GetComponent<Rigidbody>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            for(int i = 0; i<enemysInRange.Count; i++)
            {
                if(enemysInRange[i].gameObject.GetInstanceID() == other.GetInstanceID())
                {
                    enemysInRange.RemoveAt(i);
                }
            }
        }
    }

    public void attack()
    {
        for(int i=0; i<enemysInRange.Count; i++)
        {
            EnemyHealth targetHealth = enemysInRange[i].GetComponent<EnemyHealth>();
            targetHealth.TakeDamage(damage, enemysInRange[i].transform.position);
        }
    }
}
