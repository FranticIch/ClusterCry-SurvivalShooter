using CompleteProject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageManager : MonoBehaviour {

    public Transform[] spawnPoints;

    List<GameObject> enemys = new List<GameObject> { };

	void FixedUpdate () {
        /*
		for(int i=0; i< spawnPoints.Length; i++)
        {
            bool gnomdead = spawnPoints[i].GetComponent<GnomSpawner>().isDead;
            
            if(!gnomdead)
            {
                GameObject gnom = spawnPoints[i].GetComponent<GnomSpawner>().gnom;
                if (!gnom.GetComponent<EnemyHealth>().isDead)
                {
                    enemys.Add(gnom);

                }
                else if (gnom.GetComponent<EnemyHealth>().isDead)
                {
                    enemys.Remove(gnom);
                }
            }
            
        } */

    }
 
}
