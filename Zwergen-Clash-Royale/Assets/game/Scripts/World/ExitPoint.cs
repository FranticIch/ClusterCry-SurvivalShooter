using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPoint : MonoBehaviour {

	private WorldManager world;

	// Use this for initialization
	void Start() {
		world = GameObject.Find("WorldManager").GetComponent<WorldManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Player")){
			Destroy(gameObject);
			world.ResetMap();
		}
	}
}
