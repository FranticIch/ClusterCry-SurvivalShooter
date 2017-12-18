﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {

    public bool traderInRange = false;
    private bool containerInRange = false;
    private GameObject trader;
    private GameObject player;
    private GameObject container;

    public GameObject tradingMenu;


	private void Start () {
        player = gameObject;
	}

	private void Update () {
        if(containerInRange && Input.GetKeyDown(KeyCode.E)) {
            StartInteract();
        }
	}

    private void OnTriggerEnter(Collider other)
    {

        if(other.CompareTag("Container") || other.CompareTag("Trader")) {
            containerInRange = true;
            container = other.gameObject;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Trader"))
        {
            traderInRange = false;
            container = null;
        }

        if(other.CompareTag("Container")) {
            containerInRange = false;
            container = null;
        }
            
    }

    void StartTraiding()
    {
        Time.timeScale = 0;
        tradingMenu.GetComponent<Canvas>().enabled = true;
        Debug.Log("Start Trading");
        container.GetComponent<TraderScript>().Trading();
    }

    void StartInteract() {
        if (!container)
            return;

        if(container.name == "LootChest") {
            int[] loot = container.GetComponent<Container>().Loot();
            Debug.Log("Loot: ");
            Debug.Log("Coins: " + loot[0]);
            Debug.Log("Potions: " + loot[1]);
            Debug.Log("Grenades: " + loot[2]);
            Debug.Log("Ammunition: " + loot[3]);

            Inventory inventory = GetComponent<Inventory>();
            inventory.AddCoins(loot[0]);
            inventory.AddPotions(loot[1]);
            inventory.AddGrenades(loot[2]);
            inventory.AddAmmunition(loot[3]);
            inventory.AddFood(loot[4]);

        } else if (container.name == "HumanTrader") {

            StartTraiding();
        }
        
    }

    public void EndTrading()
    {
        Time.timeScale = 1;
        tradingMenu.GetComponent<Canvas>().enabled = false;
    }


}
