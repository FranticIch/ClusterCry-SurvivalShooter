using CompleteProject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {
    private Text ammo;
    private Text grenades;
    private Text coins;
    private Text potions;
    private Text food;
    public GameObject FoodGUIElement;
    public GameObject MainWeaponGuiElement;
    public GameObject SpecialWeaponGUIElement;
    public GameObject CoinGuiElement;
    public GameObject PotionGuiElement;

    public GameObject Player;
	// Use this for initialization
	void Start () {
        coins = CoinGuiElement.GetComponentInChildren<Text>();
        grenades = SpecialWeaponGUIElement.GetComponentInChildren<Text>();
        ammo = MainWeaponGuiElement.GetComponentInChildren<Text>();
        potions = PotionGuiElement.GetComponentInChildren<Text>();
        food = FoodGUIElement.GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        potions.text = "" + Player.GetComponentInChildren<Inventory>().Potions;
        coins.text = "" + Player.GetComponentInChildren<Inventory>().Coins;
        grenades.text = "" + Player.GetComponentInChildren<Grenade>().grenadesInInventory;
        ammo.text = ""+  Player.GetComponentInChildren<PlayerShooting>().BulletsInInventory;
        food.text = "" + Player.GetComponentInChildren<Inventory>().Food;
	}
}
