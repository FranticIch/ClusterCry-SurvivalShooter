using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	private int ore;

	public GameObject tool;
	public GameObject gun;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public int GetOre() {
		return ore;
	}
	
	public void AddOre(int cnt) {
		ore += cnt;
	}
	
	public bool TakeOre(int cnt) {
		if(ore >= cnt){
			ore -= cnt;
			return true;
		}
		return false;
	}
	
	public void setGun(GameObject gun) {
		if(this.gun != null) {
			//DROP GUN
		}
		
		this.gun = gun;
	}
}
