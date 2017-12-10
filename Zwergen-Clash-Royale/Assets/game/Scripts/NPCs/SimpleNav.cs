using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleNav : MonoBehaviour {

     public Transform[] Navs;
     UnityEngine.AI.NavMeshAgent agent;
 
     void Start () {
         agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
     
	 }
     
     void Update () {
		agent.SetDestination(Navs[0].position);
	 // if (agent.velocity.magnitude == 0f) {
             
         // }
     }
}
