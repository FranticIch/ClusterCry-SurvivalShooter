using System.Collections;
using System.Collections.Generic;
using CompleteProject;
using UnityEngine.UI;
using UnityEngine;

public class SkillUIManager : MonoBehaviour {
    public GameObject mainWeapon;
    public GameObject specialWeapon;

    private Text _mainWeaponTimerText;
    private Text _specialWeaponTimerText;
    private PlayerShooting _shootingScript;
    private Grenade _grenadeScript;

    // Use this for initialization
    void Start () {
        _grenadeScript = FindObjectOfType<Grenade>();
        _shootingScript = FindObjectOfType<PlayerShooting>();
        _mainWeaponTimerText = mainWeapon.GetComponentInChildren<Text>();
        _specialWeaponTimerText = specialWeapon.GetComponentInChildren<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        _mainWeaponTimerText.text =  _shootingScript.MainWeaponTimer.ToString();
        _specialWeaponTimerText.text = _grenadeScript.SpecialWeaponTimer.ToString();

    }
}
