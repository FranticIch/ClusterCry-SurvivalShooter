using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	public int ore;

	public GameObject tool;
	public GameObject gun;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void setGun(GameObject gun) {
		if(this.gun != null) {
			//DROP GUN
		}
		
		this.gun = gun;
	}
}
