using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraderScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Test(Quaternion playerrotation)
    {
        Debug.Log("Hello there");
        //transform.rotation = playerrotation*
    }
}
