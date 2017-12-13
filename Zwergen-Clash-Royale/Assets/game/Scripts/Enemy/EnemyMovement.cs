using UnityEngine;
using System.Collections;
using UnitySampleAssets.CrossPlatformInput;
using System;

namespace CompleteProject
{
    public class EnemyMovement : MonoBehaviour {
		
        Transform player;               // Reference to the player's position.
		EnemySpawner spawn;
        PlayerHealth playerHealth;      // Reference to the player's health.
        EnemyHealth enemyHealth;        // Reference to this enemy's health.
		
		public int followRadius = 10;
		
		private EnemySpawner spawner;
		
        private UnityEngine.AI.NavMeshAgent nav;          // Reference to the nav mesh agent.
        
		private Animator anim;
		private Rigidbody body;
		
        bool walking = false;
        public LayerMask spawnPoints;

        void Awake() {
            player = GameObject.FindGameObjectWithTag("Player").transform;
			body = GetComponent<Rigidbody>();
            playerHealth = player.GetComponent<PlayerHealth>();
            enemyHealth = GetComponent<EnemyHealth>();
            nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
            anim = GetComponent<Animator>();
			
			nav.enabled = true;
        }

        private void Start() {
        }

        private void Update() {
			
        }

        void FixedUpdate() {
            if (nav.enabled)
            {
                if (Vector3.Distance(transform.position, player.position) > followRadius)
                {
                    nav.SetDestination(spawner.transform.position);
                }
                else
                {
                    nav.SetDestination(player.position);
                }
            } 



            UpdateAnimator();
        }

        void UpdateAnimator() {
            Debug.Log(body.velocity.magnitude);
           anim.SetBool("IsWalking", ((int)body.velocity.magnitude) > 0);
		}
		
		public void SetSpawner(EnemySpawner spawner){
			this.spawner = spawner;
		}
    }
}