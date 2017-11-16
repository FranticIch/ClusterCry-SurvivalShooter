using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

	public string name;
	public Biome[] biomes; // MISSING DISTRIBUTION /RARITY
	// public Dictionary<GameObject, float> biomes = new Dictionary<GameObject, float>();
	
	public GameObject GenerateTileAt(int x, int z, int seed){
		return biomes[Random.Range(0, biomes.Length-1)].GetRandomTile(seed);
	}
	
}
