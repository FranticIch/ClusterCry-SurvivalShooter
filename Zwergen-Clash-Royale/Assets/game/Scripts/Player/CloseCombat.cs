using CompleteProject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCombat : MonoBehaviour {

    public int damage = 25;

    private List<Rigidbody> enemysInRange = new List<Rigidbody> { };

    private void Update()
    {
        for(int i = 0; i < enemysInRange.Count; i++)
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
