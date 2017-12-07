using CompleteProject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {
    private Text ammo;
    public GameObject Player;
	// Use this for initialization
	void Start () {
        ammo = GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        ammo.text = ""+  Player.GetComponentInChildren<PlayerShooting>().bulletsInInventory;
	}
}
