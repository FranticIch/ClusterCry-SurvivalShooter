using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour {

	public GameObject[] tilePrefabs;
	
	private List<GameObject> tiles = new List<GameObject>();
	
	private int seed;
	
	void Start () {
		GenerateStartingArea(2);
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
		tiles.Add((GameObject)Instantiate(tilePrefabs[0], new Vector3(x*10, 0, z*10), Quaternion.identity));
	}
	
	// -> Instead of generating Tiles - > Generate Chunks? Nah
	//LoadTileAt(int x, int y) 
	//CheckIfTilesExist(int x, int y) ( On Harddrive )
	//GenerateTileAt(int x, int y)
	//GenerateOrLoadTileAt(int x, int y)
	
	//Unloading
}
