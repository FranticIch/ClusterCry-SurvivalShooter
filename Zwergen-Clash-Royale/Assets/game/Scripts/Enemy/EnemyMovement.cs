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
        public GameObject spawnPoint;
        bool playerIsInRange = false;
        bool atSpawnPoint = true;
        bool walking = false;
        public LayerMask spawnPoints;
        [Tooltip("Distance from Enemy to Spawnpoint to change Animation")]
        public float preferedDistanceToSpawnpoint = 1f;


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
            nav.enabled = false;
        }

        private void Update()
        {
            
        }

        void FixedUpdate()
        {
            // Animate the enemy.
            UpdateAnimator();
            IsWalking();
            if (!walking)
                nav.enabled = false;
            
        }

        bool IsNearSpawnpoint()
        {
            return Vector3.Distance(transform.position, spawnPoint.transform.position) < preferedDistanceToSpawnpoint;
        }

        void IsWalking()
        {
            walking = playerIsInRange || !IsNearSpawnpoint();
                
        }

        void UpdateAnimator()
        {
            // Tell the animator whether or not the player is in Range so the enemy will follow him.
            anim.SetBool("IsWalking", walking);
        }

        public void RangeTrigger()
        {
            nav.enabled = true;
            nav.SetDestination(player.position);
            playerIsInRange = true;
        }

        public void NotRangeTrigger()
        {
            nav.enabled = true;
            nav.SetDestination(spawnPoint.transform.position);
            playerIsInRange = false;
        }



    }    
}