using System.Collections.Generic;
using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;

namespace CompleteProject
{
    public class PlayerShooting : MonoBehaviour
    {
        public float timeBetweenBullets = 0.15f;        // The time between each shot.
        public float timeBetweenGrenades = 2f;
        public float throwSpeed = 5f;

        public float weaponSlowdown = 1.0f;

        public Rigidbody grenade;
        public Rigidbody bullet;
        public Transform gunBarrelEnd;
        public Transform throwTransform;                    
        public Light faceLight;
        public Transform closeCombatDetector;

        float timer;                                    // A timer to determine when to fire.
        float grenadeTimer = 5f;
        float effectsDisplayTime = 0.2f;
        float waitForMovement;
        bool thrown;

        float countdownTimerMainWeapon;
        float countdownTimerSpecialWeapon;


        PlayerMovement playerMovement;
        ParticleSystem gunParticles;
        CloseCombat closeCombatScript;

        AudioSource gunAudio;
        public AudioSource punchAudio;
        
        void Awake ()
        {
            gunParticles = GetComponent<ParticleSystem> ();
            closeCombatScript = closeCombatDetector.GetComponent<CloseCombat>();
            playerMovement = GetComponentInParent<PlayerMovement>();

            gunAudio = GetComponent<AudioSource>();
            
        }

        void Update ()
        {

            // Add the time since Update was last called to the timer.
            timer += Time.deltaTime;
            grenadeTimer += Time.deltaTime;

            if (timer > timeBetweenGrenades)
            {
                thrown = false;
            }

            // If the Fire1 button is being press and it's time to fire...
            if (Input.GetButton("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
            {
                // ... shoot the gun.
                playerMovement.SlowDownModificator = 0.0f;
                ShootBullet();
                gunAudio.Play();
            }

            if (Input.GetButtonDown("Fire2") && grenadeTimer >= timeBetweenGrenades && !thrown)
            {
                playerMovement.SlowDownModificator = 0.5f;
                ThrowGrenade();
                grenadeTimer = 0;
            }

            if (Input.GetKeyDown(KeyCode.F))
            {

                playerMovement.SlowDownModificator = 0.75f;
                closeCombatScript.attack();
                punchAudio.Play();
            }


            // If the timer has exceeded the proportion of timeBetweenBullets that the effects should be displayed for...
            if (timer >= timeBetweenBullets * effectsDisplayTime)
            {
                // ... disable the effects.
                DisableEffects();
            }


            if (playerMovement.SlowDownModificator < 1.0f)
            {
                waitForMovement += Time.deltaTime;
            }
            if (waitForMovement > 1.0f)
            {
                waitForMovement = 0.0f;
                playerMovement.SlowDownModificator = 1.0f;
            }
        }

        private void FixedUpdate()
        {
            
        }


        public void DisableEffects ()
        {
			faceLight.enabled = false;
        }

        void ThrowGrenade()
        {
            thrown = true;
            Rigidbody grenadeInstance = Instantiate(grenade, throwTransform.position, throwTransform.rotation) as Rigidbody;

            grenadeInstance.velocity = throwSpeed * throwTransform.forward;
            

            //AUDIO
        
        }

        void ShootBullet()
        {
            timer = 0f;

            gunParticles.Stop();
            gunParticles.Play();

            Rigidbody bulletInstance = Instantiate(bullet, gunBarrelEnd.position, gunBarrelEnd.rotation) as Rigidbody;

            bulletInstance.velocity = 20f * gunBarrelEnd.forward;
        }

        public string MainWeaponTimer
        { 
            get
            {

                if (timer >= 0.0f && timer < timeBetweenBullets)
                {
                    countdownTimerMainWeapon -= Time.deltaTime;
                    return ""+(int) countdownTimerMainWeapon;
                }
                else
                {
                    countdownTimerMainWeapon = (int)timeBetweenBullets;
                    return "Bereit" ; 
                }
               
            }
        }

        public string SpecialWeaponTimer
        {
            get
            {
               
                if (grenadeTimer >= 0 && grenadeTimer < timeBetweenGrenades)
                {
                    countdownTimerSpecialWeapon -= Time.deltaTime;
                    return "" + (int)countdownTimerSpecialWeapon;
                }
                else
                {
                    countdownTimerSpecialWeapon = (int)timeBetweenGrenades;
                    return "Bereit";
                }
            }
        }
    }
}