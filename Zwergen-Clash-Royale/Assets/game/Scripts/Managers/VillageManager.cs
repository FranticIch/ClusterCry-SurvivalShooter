using CompleteProject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageManager : MonoBehaviour {

    public Transform[] spawnPoints;

    List<GameObject> enemys = new List<GameObject> { };

	void FixedUpdate () {
        
		for(int i=0; i< spawnPoints.Length; i++)
        {
            GameObject gnom = spawnPoints[i].GetComponent<GnomSpawner>().gnom;
            if (!gnom && !gnom.GetComponent<EnemyHealth>().isDead)
            {
                gnom.gameObject.transform.parent = gameObject.transform;
                enemys.Add(gnom);

            } else if(gnom.GetComponent<EnemyHealth>().isDead)
            {
                enemys.Remove(gnom);
            }
        } 

    }
 
}
