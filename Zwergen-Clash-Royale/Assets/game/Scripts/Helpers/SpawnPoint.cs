using CompleteProject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    public bool player = false;
    float timer = 0f;
    public float buffer = 0.5f;
    List<GameObject> enemys = new List<GameObject> { };

    private void FixedUpdate()
    {

        if(this.gameObject.GetComponentInParent<VillageManager>().isInRange)
        {
            player = true;
        }
        else
        {
            player = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy")&& !player)
        {
            other.gameObject.GetComponent<EnemyMovement>().NearSpawnPoint();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy") && player)
        {
            other.gameObject.GetComponent<EnemyMovement>().NotNearSpawnPoint();
        }
    }
}
