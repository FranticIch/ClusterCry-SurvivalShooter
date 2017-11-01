using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseRangeAttack : MonoBehaviour {

    private bool attackPossible;
    public float attackSpeed = 1.0f;
    public int attackDamage = 20;
    float timer;

    private void Start()
    {
        attackPossible = false;
    }

    private void Update()
    {
        timer += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            attackPossible = true;
        }

        if(attackPossible && timer >= attackSpeed)
        {
            //other.GetComponent<EnemyHealth>().TakeDamage(attackDamage, other.transform.position);

            timer = 0f;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            attackPossible = true;
        } else
        {
            attackPossible = false;
        }
    }

}
