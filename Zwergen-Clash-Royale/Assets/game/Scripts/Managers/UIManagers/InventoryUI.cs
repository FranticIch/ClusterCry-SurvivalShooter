using CompleteProject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {
    private Text ammo;
    private Text grenades;
    private Text coins;
    public GameObject MainWeaponGuiElement;
    public GameObject SpecialWeaponGUIElement;
    public GameObject CoinGuiElement;

    public GameObject Player;
	// Use this for initialization
	void Start () {
        coins = CoinGuiElement.GetComponentInChildren<Text>();
        grenades = SpecialWeaponGUIElement.GetComponentInChildren<Text>();
        ammo = MainWeaponGuiElement.GetComponentInChildren<Text>();
        
	}
	
	// Update is called once per frame
	void Update () {
        coins.text = "" + Player.GetComponentInChildren<Inventory>().Coins;
        grenades.text = "" + Player.GetComponentInChildren<Grenade>().grenadesInInventory;
        ammo.text = ""+  Player.GetComponentInChildren<PlayerShooting>().bulletsInInventory;
	}
}
