using CompleteProject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageManager : MonoBehaviour {

    public Transform spawnPoint;
    public float spawntime = 30f;
    public GameObject enemy;

    List<GameObject> enemys = new List<GameObject> { };
    int count = 0;

    // Use this for initialization
    void Start () {
        InvokeRepeating("Spawn", 0f, 2f);
	}
	

	void FixedUpdate () {
		for(int i=0; i< enemys.Count; i++)
        {
            if (enemys[i]==null)
            {
                enemys.RemoveAt(i);
            }
        }
	}

    void Spawn()
    {
        if(enemys.Count<3)
        {
            enemys.Add(Instantiate(enemy, spawnPoint.position, spawnPoint.rotation));
            
        }

    }
    
}
