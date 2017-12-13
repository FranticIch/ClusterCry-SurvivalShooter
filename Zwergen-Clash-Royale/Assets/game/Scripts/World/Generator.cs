using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

	public string name;
	public int chunkSize;
	public Biome[] biomes;
	
	private Biome RandomBiome() {
		return biomes[Random.Range(0, biomes.Length)];
	}
	
	private GameObject GenerateTileAt(int x, int z, int seed){
		return RandomBiome().GetRandomTile(seed);
	}		
		
	private GameObject InstantiateTileAt(int x, int z, int seed, Transform parent) {
		GameObject tile = (GameObject)Instantiate(GenerateTileAt(x, z, seed), new Vector3(x*15, 0, z*15), Quaternion.identity);
		tile.transform.parent = parent;
		return tile;
	}
	
	private Vector3 ChooseRandomTileLocation() {
		return new Vector3(Random.Range(0, chunkSize), 0 , Random.Range(0, chunkSize));
	}
	
	private void GenerateBorders(List<GameObject> tiles, int originX, int originZ, Transform parent) {

	}
	
	private bool PositionIsEqual(int x, int z, Vector3 pos) {
		return pos.x == x && pos.z == z;
	}

	private void GenerateInside(List<GameObject> tiles, int originX, int originZ, int seed, Transform parent) {
		
		Vector3 spawn = ChooseRandomTileLocation();
		Vector3 exit;
		do {
			exit = ChooseRandomTileLocation();
		} while(exit.x == spawn.x && exit.z == spawn.z);
		
		for(int z = 0; z < chunkSize; z++) {
			for(int x = 0; x < chunkSize; x++) {
				if(PositionIsEqual(x, z, spawn)) {
					Debug.Log("Generated Spawn at " + spawn.x + " " + spawn.z);
					tiles.Add((GameObject)Instantiate(RandomBiome().spawnTilePrefab, new Vector3(x*15, 0, z*15), Quaternion.identity));
				}
				else if(PositionIsEqual(x, z, exit)) {
					Debug.Log("Generated Exit at " + exit.x + " " + exit.z);
					tiles.Add((GameObject)Instantiate(RandomBiome().exitTilePrefab, new Vector3(x*15, 0, z*15), Quaternion.identity));
				}
				else {
					tiles.Add(InstantiateTileAt(originX + x, originZ + z, seed, parent));
				}
			}
		}	
	}

	
	public List<GameObject> GenerateChunkAt(int originX, int originZ, int seed, Transform parent) {
		List<GameObject> tiles = new List<GameObject>();
		GenerateInside(tiles, originX, originZ, seed, parent);
		return tiles;
	}
}
