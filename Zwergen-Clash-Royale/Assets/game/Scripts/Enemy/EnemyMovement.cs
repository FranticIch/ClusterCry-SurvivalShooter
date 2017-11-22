using UnityEngine;
using System.Collections;
using UnitySampleAssets.CrossPlatformInput;
using System;

namespace CompleteProject
{
    public class EnemyMovement : MonoBehaviour
    {
        Transform player;               // Reference to the player's position.
        PlayerHealth playerHealth;      // Reference to the player's health.
        EnemyHealth enemyHealth;        // Reference to this enemy's health.
        public UnityEngine.AI.NavMeshAgent nav;          // Reference to the nav mesh agent.
        Animator anim;
        public GameObject village;
        Transform spawnPoint;
        bool isInRange = false;
        public LayerMask enemyMask;


        void Awake ()
        {
            // Set up the references.
            player = GameObject.FindGameObjectWithTag ("Player").transform;
            playerHealth = player.GetComponent <PlayerHealth> ();
            enemyHealth = GetComponent <EnemyHealth> ();
            nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
            anim = GetComponent<Animator>();
            
        }

        private void Start()
        {
            spawnPoint = village.transform;
        }

        void Update ()
        {

            if(isInRange)
            {
                nav.SetDestination (player.position);
            }

            else
            {
                nav.SetDestination(spawnPoint.position);
            }

            NearSpawnPoint();
        }

        private void NearSpawnPoint()
        {
            Collider[] colliders = Physics.OverlapSphere(spawnPoint.position, 1f, enemyMask);

            for(int i=0; i<colliders.Length; i++)
            {
                Debug.Log(colliders[i].name);
                Debug.Log(colliders[i].GetInstanceID());
                Debug.Log(this.GetInstanceID());

                if (colliders[i].gameObject.GetInstanceID() == this.gameObject.GetInstanceID())
                    {
                        Debug.Log("Bleib stehen");
                        anim.SetTrigger("Stand");
                    } else
                    {
                        Debug.Log("Lauf");
                        anim.SetTrigger("Move");
                    }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Player"))
            {
                isInRange = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if(other.CompareTag("Player"))
            {
                isInRange = false;
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                isInRange = true;
            }
        }
    }
}