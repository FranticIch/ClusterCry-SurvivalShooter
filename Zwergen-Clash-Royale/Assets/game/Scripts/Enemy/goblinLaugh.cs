using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goblinLaugh : MonoBehaviour {

    public float timeBeetweenLaughs = 5;
    AudioSource laugh;

    float timer = 0f;

    private void Start()
    {
        laugh = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;

        if(timer> timeBeetweenLaughs)
        {
            laugh.Play();

            timer = 0f;
        }       

	}
}
