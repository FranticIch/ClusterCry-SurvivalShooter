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
	
	private GameObject InstantiateWithParent(GameObject prefab, Vector3 pos, Quaternion rot, Transform parent) {
		GameObject o = (GameObject)Instantiate(prefab, pos, rot);
		o.transform.parent = parent;
		return o;
	}
	
	private GameObject GenerateTileAt(int x, int z, int seed){
		return RandomBiome().GetRandomTile(seed);
	}		
		
	private GameObject InstantiateTileAt(int x, int z, int seed, Transform parent) {
		return (GameObject)InstantiateWithParent(GenerateTileAt(x, z, seed), new Vector3(x*15, 0, z*15), Quaternion.identity, parent);
	}
	
	private Vector3 ChooseRandomTileLocation(int min, int max) {
		return new Vector3(Random.Range(min, max), 0 , Random.Range(min, max));
	}
	
	private bool PositionIsEqual(int x, int z, Vector3 pos) {
		return pos.x == x && pos.z == z;
	}
	
	private void GenerateBorders(List<GameObject> tiles, int originX, int originZ, Transform parent) {
	
		//BOTTOM LEFT
		tiles.Add((GameObject)InstantiateWithParent(RandomBiome().borderCornerTilePrefab, new Vector3(originX*15, 0, originZ*15), Quaternion.Euler(0,180,0), parent));
		for(int i = 1; i < chunkSize-1; i++) {
			tiles.Add((GameObject)InstantiateWithParent(RandomBiome().borderTilePrefab, new Vector3((originX+i)*15, 0, originZ*15), Quaternion.Euler(0,180,0), parent));
		}
		//BOTTOM RIGHT
		tiles.Add((GameObject)InstantiateWithParent(RandomBiome().borderCornerTilePrefab, new Vector3((originX+chunkSize-1)*15, 0, originZ*15), Quaternion.Euler(0,90,0), parent));
		
		//MIDDLE
		for(int i = 1; i < chunkSize-1; i++) {
			tiles.Add((GameObject)InstantiateWithParent(RandomBiome().borderTilePrefab, new Vector3((originX)*15, 0, (originZ+i)*15), Quaternion.Euler(0,-90,0), parent));
			tiles.Add((GameObject)InstantiateWithParent(RandomBiome().borderTilePrefab, new Vector3((originX+chunkSize-1)*15, 0, (originZ+i)*15), Quaternion.Euler(0,90,0), parent));
		}
		
		//TOP LEFT
		tiles.Add((GameObject)InstantiateWithParent(RandomBiome().borderCornerTilePrefab, new Vector3(originX*15, 0, (originZ+chunkSize-1)*15), Quaternion.Euler(0,-90,0), parent));
		for(int i = 1; i < chunkSize-1; i++) {
			//TOP MID ROW
			tiles.Add((GameObject)InstantiateWithParent(RandomBiome().borderTilePrefab, new Vector3((originX+i)*15, 0, (originZ+chunkSize-1)*15), Quaternion.identity, parent));
		}
		//TOP RIGHT
		tiles.Add((GameObject)InstantiateWithParent(RandomBiome().borderCornerTilePrefab, new Vector3((originX+chunkSize-1)*15, 0, (originZ+chunkSize-1)*15), Quaternion.identity, parent));
	}

	private void GenerateInside(List<GameObject> tiles, int originX, int originZ, int seed, Transform parent) {
		
		Vector3 spawn = ChooseRandomTileLocation(1, chunkSize-1);
		Vector3 exit;
		do {
			exit = ChooseRandomTileLocation(1, chunkSize-1);
		} while(exit.x == spawn.x && exit.z == spawn.z);
		
		for(int z = 1; z < chunkSize-1; z++) {
			for(int x = 1; x < chunkSize-1; x++) {
				if(PositionIsEqual(x, z, spawn)) {
					Debug.Log("Generated Spawn at " + spawn.x + " " + spawn.z);
					tiles.Add((GameObject)InstantiateWithParent(RandomBiome().spawnTilePrefab, new Vector3((originX+x)*15, 0, (originZ+z)*15), Quaternion.identity, parent));
				}
				else if(PositionIsEqual(x, z, exit)) {
					Debug.Log("Generated Exit at " + exit.x + " " + exit.z);
					tiles.Add((GameObject)InstantiateWithParent(RandomBiome().exitTilePrefab, new Vector3((originX+x)*15, 0, (originZ+z)*15), Quaternion.identity, parent));
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
		GenerateBorders(tiles, originX, originZ, parent);
		return tiles;
	}
}
