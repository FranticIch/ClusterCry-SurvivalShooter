using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DayNightManagerUI : MonoBehaviour {

    private Image _daynightuiImage;
    private DayNightManager _daynightmanager;
	// Use this for initialization
	void Start () {
        _daynightuiImage = gameObject.GetComponent<Image>();
        _daynightmanager = FindObjectOfType<DayNightManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (_daynightmanager.Night)
        {
            _daynightuiImage.color = Color.black;
        }
        else
        {
            _daynightuiImage.color = Color.yellow;
        }
		
	}
}
