using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightManager : MonoBehaviour {
    public bool night = false;
    public GameObject lightObject;
    private Light light;
    private float elapsed;

    //Anpasspar
    private float timeForEffect;

    public float selectedTimeForEffect;
    public float maxLightIntensity;
    public float minLightIntensity;

    // Use this for initialization
    void Start () {
        timeForEffect = selectedTimeForEffect;
        elapsed = 0.0f;
        light = lightObject.GetComponent<Light>();
        light.intensity = maxLightIntensity;
    }
	
	// Update is called once per frame
	void Update () {
        if(timeForEffect > elapsed)
        {
            if (night)
            {
                light.intensity = Mathf.Lerp(minLightIntensity, maxLightIntensity, elapsed / timeForEffect);
            }
            else
            {
                light.intensity = Mathf.Lerp(maxLightIntensity, minLightIntensity, elapsed / timeForEffect);
            }

            elapsed += Time.deltaTime;
        }
        else
        {
            timeForEffect = selectedTimeForEffect;
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
