using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumièreJoueur : MonoBehaviour
{
    public Light TorcheJoueur;


    float defaultIntensity;
    //float intensiteactu = 0;
    float timer = 0;

    void Start()
    {
        TorcheJoueur.intensity = defaultIntensity;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 0.1) {
            timer = 0;
            TorcheJoueur.intensity = defaultIntensity + Random.Range(1.8f, 2f);

        }
    }
   
}
