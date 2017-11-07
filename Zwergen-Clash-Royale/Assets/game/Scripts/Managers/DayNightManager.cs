using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightManager : MonoBehaviour {
    public bool night = false;
    public GameObject lightObject;
    private Light light;
    private float elapsed;
    private float timeForEffect = 300.0f;

    // Use this for initialization
    void Start () {
        elapsed = 0.0f;
        light = lightObject.GetComponent<Light>();
        light.intensity = 1.2f;
    }
	
	// Update is called once per frame
	void Update () {
        if(timeForEffect > elapsed)
        {
            if (night)
            {
                light.intensity = Mathf.Lerp(0.1f, 1.2f, elapsed / timeForEffect);
            }
            else
            {
                light.intensity = Mathf.Lerp(1.2f, 0.1f, elapsed / timeForEffect);
            }

            elapsed += Time.deltaTime;
        }
        else
        {
            timeForEffect = 300.0f;
            if (night)
            {
                night = false;
            }
            else
            {
                night = true;
            }
        }
	}

}
