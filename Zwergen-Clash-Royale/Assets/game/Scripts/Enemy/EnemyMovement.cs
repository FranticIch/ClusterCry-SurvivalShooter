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


        void Awake()
        {
            // Set up the references.
            player = GameObject.FindGameObjectWithTag("Player").transform;
            playerHealth = player.GetComponent<PlayerHealth>();
            enemyHealth = GetComponent<EnemyHealth>();
            nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
            anim = GetComponent<Animator>();

        }

        private void Start()
        {
            spawnPoint = village.transform;
            nav.enabled = false;
        }

        void Update()
        {            
        }

        public void RangeTrigger()
        {
            nav.enabled = true;
            nav.SetDestination(player.position);
            isInRange = true;
        }

        public void NotRangeTrigger()
        {
            nav.enabled = true;
            nav.SetDestination(spawnPoint.position);
            isInRange = false;
        }

        public void NearSpawnPoint()
        {
            nav.enabled = false;
            anim.SetTrigger("Stand");
        }

    }    
}