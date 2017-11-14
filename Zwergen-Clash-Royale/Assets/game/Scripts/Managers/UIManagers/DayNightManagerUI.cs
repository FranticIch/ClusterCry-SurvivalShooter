using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DayNightManagerUI : MonoBehaviour {

    private Image _daynightuiImage;
    private DayNightManager _daynightmanager;
    private Text clock;
    public Sprite[] sprites;
	// Use this for initialization
	void Start () {
        _daynightuiImage = gameObject.GetComponent<Image>();
        _daynightmanager = FindObjectOfType<DayNightManager>();
        clock = gameObject.GetComponentInChildren<Text>();
    }
	
	// Update is called once per frame
	void Update () {
       
        if (_daynightmanager.GetTime > 0.4f && _daynightmanager.GetTime < 0.8f)
        {
            _daynightuiImage.sprite =  sprites[1];
        }
        else if(_daynightmanager.GetTime < 0.4f)
        {
            _daynightuiImage.sprite = sprites[0];
        }
        else
        {
            _daynightuiImage.sprite = sprites[2];
        }

        if (_daynightmanager.night)
        {
            clock.text = (int)(_daynightmanager.GetTime * 10) + ":00";
        }
        else
        {
            clock.text = (int)(24 - _daynightmanager.GetTime * 10) + ":00";
        }
		
	}
}
