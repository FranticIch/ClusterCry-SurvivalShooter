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

        float waitForGrenade;
        bool startGrenadeTimer;

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

        AudioSource gunAudio;
        public AudioSource punchAudio;
        
        void Awake ()
        {
            rotationAllowed = true;
            meleeAllowed = true;

            Musket.SetActive(false);
            MusketBack.SetActive(true);

            gunParticles = GetComponent<ParticleSystem> ();
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

            // If the Fire1 button is being press and it's time to fire...
            if (Input.GetButton("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0 && rotationAllowed)
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
                startMusketTimer = false;
                rotationAllowed = true;
                waitForMusket = 0.0f;
            }

            //Granatenskript
            grenadeTimer += Time.deltaTime;

            if (timer > timeBetweenGrenades)
            {
                thrown = false;
            }


            if (Input.GetButtonDown("Fire2") && grenadeTimer >= timeBetweenGrenades && !thrown)
            {
                anim.SetTrigger("Grenade");
                playerMovement.SlowDownModificator = 0.5f;
                waitForGrenade = 0.0f;
                startGrenadeTimer = true;
                waitForGrenade = 0.0f;
                grenadeTimer = 0;

            }

            if (startGrenadeTimer)
            {
                waitForGrenade += Time.deltaTime;
            }

            if(waitForGrenade >= 1f)
            {
                waitForMusket = 0.0f;
                ThrowGrenade();
                startGrenadeTimer = false;
            }

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

        void ThrowGrenade()
        {
            thrown = true;
            Rigidbody grenadeInstance = Instantiate(grenade, throwTransform.position, throwTransform.rotation) as Rigidbody;

            grenadeInstance.velocity = throwSpeed * throwTransform.forward;
            waitForGrenade = 0.0f;
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

        public bool MusketTimer
        {
            get
            {
                return startMusketTimer;
            }
        }
    }
}