using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraderScript : MonoBehaviour {

    Animator anim;

	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Trading()
    {
        anim.SetTrigger("Greeting");
        Debug.Log("Hello there");
    }

}
