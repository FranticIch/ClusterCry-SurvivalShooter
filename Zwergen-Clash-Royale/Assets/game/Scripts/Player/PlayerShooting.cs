using System.Collections.Generic;
using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;

namespace CompleteProject
{
    public class PlayerShooting : MonoBehaviour
    {
        public float timeBetweenBullets = 0.15f;        // The time between each shot.


        public float weaponSlowdown = 1.0f;


        public Rigidbody bullet;
        public GameObject gunBarrelEnd;                  
        public Light faceLight;
        public Transform closeCombatDetector;
        //public Inventory inventory;

        float timer;                                    // A timer to determine when to fire.

        float effectsDisplayTime = 0.2f;
        float waitForMovement;


        int musketAmmunition = 5;

        float countdownTimerMainWeapon;



        float waitForMusket;
        bool startMusketTimer;
        bool hasToLoad;
        bool rotationAllowed;
        bool meleeAllowed;
        float meleeTimer;

        Animator anim;
        PlayerMovement playerMovement;
        ParticleSystem gunParticles;
        CloseCombat closeCombatScript;


        public GameObject Musket;
        public GameObject MusketBack;
        public GameObject Player;
        public GameObject Pickaxe;

        AudioSource gunAudio;
        public AudioSource punchAudio;
        
        void Awake ()
        {
            rotationAllowed = true;
            meleeAllowed = true;

            Musket.SetActive(false);
            MusketBack.SetActive(true);
            Pickaxe.SetActive(true);

            gunParticles = gunBarrelEnd.GetComponent<ParticleSystem> ();
            closeCombatScript = closeCombatDetector.GetComponent<CloseCombat>();
            playerMovement = GetComponentInParent<PlayerMovement>();

            gunAudio = GetComponent<AudioSource>();

            anim = GetComponentInParent<Animator>();

           
        }

        void Update ()
        {
            // Add the time since Update was last called to the timer.
            timer += Time.deltaTime;
            meleeTimer += Time.deltaTime;

            //grenadeAmmunition = grenadesInInventory;
            //musketAmmunition = bulletsInInventory;

            // If the Fire1 button is being press and it's time to fire...
            if (Input.GetButton("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0 && rotationAllowed && /*bulletsInInventory*/musketAmmunition>0)
            {
                rotationAllowed = false;


                // ... shoot the gun.
                playerMovement.SlowDownModificator = 0.0f;
                startMusketTimer = true;
                hasToLoad = false;
                waitForMusket = 0.0f;
                Player.transform.Rotate(new Vector3(0, 45));
                anim.SetTrigger("Shoot");

            }

            if (startMusketTimer)
            {
                waitForMusket += Time.deltaTime;
            }

            if(waitForMusket >= 0.2f && !hasToLoad)
            {
                Musket.SetActive(true);
                MusketBack.SetActive(false);
                Pickaxe.SetActive(false);
            }

            if (waitForMusket >=0.5f && !hasToLoad)
            {
                hasToLoad = true;
                ShootBullet();
                gunAudio.Play();


            }

            if (waitForMusket >= 1.0f)
            {
                Musket.SetActive(false);
                MusketBack.SetActive(true);
                Pickaxe.SetActive(true);
                startMusketTimer = false;
                rotationAllowed = true;
                waitForMusket = 0.0f;
            }

            //Granatenskript
            

            

            //Nahkampfskript


            if (Input.GetKeyDown(KeyCode.F) && meleeAllowed)
            {
                meleeTimer = 0.0f;
                meleeAllowed = false;
                playerMovement.SlowDownModificator = 0.75f;
                anim.SetTrigger("Attack");

            }

            if(meleeTimer >= 1.0f && !meleeAllowed)
            {
                closeCombatScript.attack();
                punchAudio.Play();
                meleeAllowed = true;

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


        public void DisableEffects ()
        {
			faceLight.enabled = false;
        }

        

        void ShootBullet()
        {
            timer = 0f;

            gunParticles.Stop();
            gunParticles.Play();

            Rigidbody bulletInstance = Instantiate(bullet, gunBarrelEnd.transform.position, gunBarrelEnd.transform.rotation) as Rigidbody;

            bulletInstance.velocity = 20f * gunBarrelEnd.transform.forward;

            musketAmmunition--;
            //invetory.removeItem("bullet");
            Debug.Log("Kugeln: " + musketAmmunition);
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

        

        public bool MusketTimer
        {
            get
            {
                return startMusketTimer;
            }
        }

        public int bulletsInInventory
        {
            get
            {
                //return invetory.bullets;
                return 5;
            }
        }

        
    }
}