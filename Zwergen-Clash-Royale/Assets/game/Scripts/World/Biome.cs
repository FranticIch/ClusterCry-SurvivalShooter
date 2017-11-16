using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Biome : MonoBehaviour {
	
	public string name;
	
	public GameObject[] tilePrefabs;
	
	// Use this for initialization
	void Start () {
		if (tilePrefabs.Length == 0)
			//throw new Exception("Biome " + name + " was initialized without tilePrefabs.");	
			Debug.LogError("Biome " + name + " was initialized without tilePrefabs.");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public GameObject GetRandomTile(int seed) {
		return tilePrefabs[Random.Range(0, tilePrefabs.Length-1)];
	}
}
