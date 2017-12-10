using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour {

	public Generator generator;
    public int worldSize;
	
	private NavMeshGenerator navGen;
	
	private List<GameObject> tiles = new List<GameObject>();
	
	private int seed;
	
	void Start () {
		navGen = GetComponent<NavMeshGenerator>();
		GenerateChunk();
	}
	
	void Update () {
		
	}
	
	void GenerateChunk() {
		//Add Offset
		for(int z = 0; z < generator.chunkSize; z++) {
			for(int x = 0; x < generator.chunkSize; x++) {
				GenerateTileAt(x, z);
			}
		}
		navGen.RecalculateMesh(generator.chunkSize/2, new Vector3(generator.chunkSize/2, 0, generator.chunkSize/2));
	}
	
	void GenerateTileAt(int x, int z) {
		GameObject tile = (GameObject)Instantiate(generator.GenerateTileAt(x, z, seed), new Vector3(x*15, 0, z*15), Quaternion.identity);
		tile.transform.parent = transform;
		tiles.Add(tile);
	}
}