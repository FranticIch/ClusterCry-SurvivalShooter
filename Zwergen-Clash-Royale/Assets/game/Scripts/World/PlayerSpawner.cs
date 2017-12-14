using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject player = GameObject.FindWithTag("Player");
		player.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
