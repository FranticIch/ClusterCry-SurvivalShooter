using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	public int ammo = 0;

	public float timeBetweenBullets = 0.15f;
	public float weaponPutBackDelay = 0.2f;

	public float weaponSlowdown = 1.0f;
	public float bulletSpeed = 20;
		
	public Light faceLight;
	
	float effectsDisplayTime = 0.2f;
	
	float countdownTimerMainWeapon; // Wofür ist timeBetweenBullets dann???
	
	bool rotationAllowed;
	
	
	Animator anim;
	ParticleSystem particles;
	AudioSource audio; // Try to move out
	//PlayerMovement playerMovement; //CHECK IF SHOULD BE HERE // SEND EVENT?
	
	public GameObject bullet;
	public GameObject gunBarrelEnd; // AAAAAAAAAAAAAAAAAAAAAAA point wäre besser
	public GameObject gun;
	public GameObject gunBack; // Auf dem Rücken ( Währe eine Pos nicht besser, als ein 2. Modell? )
	public GameObject player; // public??
	

	private float lastShot;
	
	void Awake () {
		
		lastShot = Time.time;
		
		rotationAllowed = true;    

		Unarm();

		particles = gunBarrelEnd.GetComponent<ParticleSystem> ();
		audio = GetComponent<AudioSource>();
		anim = GetComponentInParent<Animator>();
		
		//playerMovement = GetComponentInParent<PlayerMovement>();
	}
		
	void Update () {
		if(CanShoot()){
			rotationAllowed = true;
			Arm();
			DisableEffects();
			// playerMovement.SlowDownModificator = 0.0f;
		}
	}
	
	void Arm() {
		gun.SetActive(true);
		gunBack.SetActive(false);
	}
	
	void Unarm() {
		gun.SetActive(false);
		gunBack.SetActive(true);
	}
	
	bool CanShoot() {
		return Time.time >= lastShot + timeBetweenBullets && ammo > 0;
	}
	
	void Shoot() {
		
		if(!CanShoot())
			return; // Play Click?
		
		lastShot = Time.time;
		
		rotationAllowed = false;
		
		if(particles){
			particles.Stop(); // wtf?
			particles.Play();
		}
		if(audio)
			audio.Play();
		//player.transform.Rotate(new Vector3(0, 45));
		if(anim)
			anim.SetTrigger("Shoot");

		GameObject bulletInstance = Instantiate(bullet, gunBarrelEnd.transform.position, gunBarrelEnd.transform.rotation);

		bulletInstance.GetComponent<Rigidbody>().velocity = bulletSpeed * gunBarrelEnd.transform.forward;

		ammo--;
	}
	
	public void DisableEffects () {
		faceLight.enabled = false;
    }
}
