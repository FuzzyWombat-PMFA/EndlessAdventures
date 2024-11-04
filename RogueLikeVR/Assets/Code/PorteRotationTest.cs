using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PorteRotationTest : MonoBehaviour
{

    public static bool poignéetouché = false;
    public static float Ouverture = 0;
    public static float porte = 0;


    public void OuvertureNord()
    {
        porte = 0;
        Ouverture = 0;
        poignéetouché = true;
    }
    void Update()
    {
        if (poignéetouché)
        {

            if (porte + Ouverture < 90)
            {
                Ouverture = 20f * Time.deltaTime;
                porte += Ouverture;
                transform.Rotate(0, Ouverture, 0);
            }
            else
            {
                Ouverture = 90 - porte;
                porte = 90;
                transform.Rotate(0, Ouverture, 0);
                Ouverture = 0;
                poignéetouché = false;
            }


        }
    }
}
            
    
        
        
        
            


