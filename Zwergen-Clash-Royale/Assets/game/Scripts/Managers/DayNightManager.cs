using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightManager : MonoBehaviour {
    public bool night;
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
                Debug.Log("NAcht");
                light.intensity = Mathf.Lerp(minLightIntensity, maxLightIntensity, elapsed / timeForEffect);
            }
            else
            {
                Debug.Log("Tag");
                light.intensity = Mathf.Lerp(maxLightIntensity, minLightIntensity, elapsed / timeForEffect);
            }

            elapsed += Time.deltaTime;
        }
        else
        {
           
            if (night)
            {
                night = false;

            }
            else
            {
                night = true;
            }

            timeForEffect = selectedTimeForEffect;
            elapsed = 0.0f;
        }
	}

}
