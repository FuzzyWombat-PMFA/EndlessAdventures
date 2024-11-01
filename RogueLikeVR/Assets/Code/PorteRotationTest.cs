using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteRotationTest : MonoBehaviour
{
    float porte = 0;
    float Ouverture = 1;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("reçu");
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 0.02f)
        {
            timer = 0;
            if (porte + Ouverture < 90)
            {
                Ouverture += 0.2f;
                porte += Ouverture;
                transform.Rotate(0, Ouverture, 0);
            }
            else
            {
                Ouverture = 90 - porte;
                transform.Rotate(0, Ouverture, 0);
            }
            
        }
        
            

    }
}
