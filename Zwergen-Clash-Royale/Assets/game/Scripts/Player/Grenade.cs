using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {
    public float timeBetweenGrenades = 2f;
    public float throwSpeed = 5f;

    public Rigidbody grenade;

    float timer;
    float grenadeTimer = 5f;
    bool thrown;
    int ammunition = 3;
    float countdownTimerSpecialWeapon;
    float waitForGrenade;
    bool startGrenadeTimer;

    Animator anim;

    void Awake() {
        anim = GetComponentInParent<Animator>();
    }
    // Use this for initialization
    void Start () {
        timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;
        grenadeTimer += Time.deltaTime;

        if (timer > timeBetweenGrenades)
        {
            thrown = false;
        }


        if (Input.GetButtonDown("Fire2") && grenadeTimer >= timeBetweenGrenades && !thrown && /* bulletsInInventory */ ammunition > 0)
        {
            anim.SetTrigger("Grenade");
            //playerMovement.SlowDownModificator = 0.5f;
            waitForGrenade = 0.0f;
            startGrenadeTimer = true;
            waitForGrenade = 0.0f;
            grenadeTimer = 0;

            //Pickaxe.SetActive(false);

        }

        if (startGrenadeTimer)
        {
            waitForGrenade += Time.deltaTime;
        }

        if (waitForGrenade >= 1f)
        {
            //waitForMusket = 0.0f;
            ThrowGrenade();
            startGrenadeTimer = false;
            //Pickaxe.SetActive(true);
        }
    }

    void ThrowGrenade()
    {
        thrown = true;
        Rigidbody grenadeInstance = Instantiate(grenade, transform.position, transform.rotation) as Rigidbody;

        grenadeInstance.velocity = throwSpeed * transform.forward;
        waitForGrenade = 0.0f;
        ammunition--;
        //AUDIO
        //inventory.removeItem("grenade");
        Debug.Log("Granaten: " + ammunition);
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

    public int grenadesInInventory
    {
        get
        {
            //return inventory.grenades
            return 3;
        }
    }
}
