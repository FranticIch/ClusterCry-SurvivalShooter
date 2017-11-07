using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;

namespace CompleteProject
{
    public class PlayerShooting : MonoBehaviour
    {
        public int damagePerShot = 20;                  // The damage inflicted by each bullet.
        public float timeBetweenBullets = 0.15f;        // The time between each shot.
        public float timeBetweenGrenades = 2f;
        public float range = 100f;                      // The distance the gun can fire.

        public Rigidbody grenade;
        public Transform throwTransform;
        public float throwSpeed = 5f;

        public Rigidbody bullet;
        public Transform gunBarrelEnd;



        float timer;                                    // A timer to determine when to fire.
        float grenadeTimer = 5f;
        Ray shootRay = new Ray();                       // A ray from the gun end forwards.
        RaycastHit shootHit;                            // A raycast hit to get information about what was hit.
        int shootableMask;                              // A layer mask so the raycast only hits things on the shootable layer.
        ParticleSystem gunParticles;                    // Reference to the particle system.
        LineRenderer gunLine;                           // Reference to the line renderer.
        AudioSource gunAudio;                           // Reference to the audio source.
        Light gunLight;                                 // Reference to the light component.
		public Light faceLight;								// Duh
        float effectsDisplayTime = 0.2f;                // The proportion of the timeBetweenBullets that the effects will display for.

        private bool thrown;

        private void OnEnable()
        {

        }


        void Awake ()
        {
            // Create a layer mask for the Shootable layer.
            shootableMask = LayerMask.GetMask ("Shootable");

            // Set up the references.
            gunParticles = GetComponent<ParticleSystem> ();
            gunLine = GetComponent <LineRenderer> ();
            gunAudio = GetComponent<AudioSource> ();
			//faceLight = GetComponentInChildren<Light> ();
        }

        private void Start()
        {
        }


        void Update ()
        {
            // Add the time since Update was last called to the timer.
            timer += Time.deltaTime;
            grenadeTimer += Time.deltaTime;

            if(timer>timeBetweenGrenades)
            {
                thrown = false;
            }

            // If the Fire1 button is being press and it's time to fire...
			if(Input.GetButton ("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
            {
                // ... shoot the gun.
                //Shoot ();
                ShootBullet();
            }

            if(Input.GetButtonDown("Fire2") && grenadeTimer >= timeBetweenGrenades && !thrown )
            {
                ThrowGrenade ();
                grenadeTimer = 0;
            }
            

            // If the timer has exceeded the proportion of timeBetweenBullets that the effects should be displayed for...
            if(timer >= timeBetweenBullets * effectsDisplayTime)
            {
                // ... disable the effects.
                DisableEffects ();
            }
        }


        public void DisableEffects ()
        {
            // Disable the line renderer and the light.
            gunLine.enabled = false;
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
    }
}