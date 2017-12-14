using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour {

	public Generator generator;
    public int worldSize;
	
	public Transform player;
	
	private NavMeshGenerator navGen;
	
	private List<GameObject> tiles = new List<GameObject>();
	
	private int seed = 0;
	
	void Start () {
		navGen = GetComponent<NavMeshGenerator>();
		ResetMap();
	}
	
	void Update () {
		
	}
	
	public void ResetMap() {
		DestroyTiles();
		//Add Offset
		Debug.Log("RESET MAP");
		tiles = generator.GenerateChunkAt(0, 0, seed, transform);
		
		navGen.RecalculateMesh(generator.chunkSize, new Vector3(generator.chunkSize/2, 0, generator.chunkSize/2));
	}
	
	void DestroyTiles() {
		// foreach(GameObject tile in tiles) {
			// tiles.Remove(tile);
			// Destroy(tile);
		// }
		while(tiles.Count > 0){
			GameObject tile = tiles[0];
			tiles.Remove(tile);
			Destroy(tile);
		}
	}
}