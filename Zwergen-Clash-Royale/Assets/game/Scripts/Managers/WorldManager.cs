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
	
	void ResetMap() {
		//Add Offset
		tiles = generator.GenerateChunkAt(0, 0, seed, transform);
		GameObject spawn = GameObject.FindWithTag("PlayerSpawn");
		
		if(spawn == null){
			Debug.Log("Could not find PlayerSpawn");
		}
		else{
			player.position = GameObject.FindWithTag("PlayerSpawn").transform.position;
			player.position = new Vector3(player.position.x, 0, player.position.z);
		}
		
		navGen.RecalculateMesh(generator.chunkSize, new Vector3(generator.chunkSize/2, 0, generator.chunkSize/2));
	}
	
	void DestroyTiles() {
		foreach(GameObject tile in tiles) {
			Destroy(tile);
			tiles.Remove(tile);
		}
	}
}