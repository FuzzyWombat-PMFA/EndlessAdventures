using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PorteRotationSud : MonoBehaviour
{

    static bool poign�etouch�S = false;
    static float Ouverture = 0;
    static float porte = 0;
    static int porteouverteS= 1;


    public void OuvertureSud()
    {
        if (!poign�etouch�S) {
            porte = 0;
            Ouverture = 0;
            poign�etouch�S = true;
        }
        
    }
    void Update()
    {
        if (poign�etouch�S)
        {
            if (porte + Ouverture < 90)
            {
                Ouverture = 40f * Time.deltaTime;
                porte += Ouverture;
                transform.Rotate(0, Ouverture*porteouverteS, 0);
            }
            else
            {
                Ouverture = 90 - porte;
                porte = 0;
                transform.Rotate(0, Ouverture*porteouverteS, 0);
                Ouverture = 0;
                poign�etouch�S = false;
                porteouverteS = porteouverteS==1 ? -1 : 1;
            }


        }
    }
}
            
    
        
        
        
            


