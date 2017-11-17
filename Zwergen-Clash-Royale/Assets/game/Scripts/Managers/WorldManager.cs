using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour {

	public Generator generator;
	
	private List<GameObject> tiles = new List<GameObject>();
	
	private int seed;
	
	void Start () {
		GenerateStartingArea(10);
	}
	
	void Update () {
		
	}
	
	void GenerateStartingArea(int size) {
		for(int z = 0; z < size; z++) {
			for(int x = 0; x < size; x++) {
				GenerateTileAt(x, z);
			}
		}
	}
	
	void GenerateTileAt(int x, int z) {
		GameObject tile = (GameObject)Instantiate(generator.GenerateTileAt(x, z, seed), new Vector3(x*10, 0, z*10), Quaternion.identity);
		tile.transform.parent = transform;
		tiles.Add(tile);
	}
}
