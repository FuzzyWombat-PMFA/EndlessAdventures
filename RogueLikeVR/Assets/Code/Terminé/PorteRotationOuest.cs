using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PorteRotationOuest : MonoBehaviour
{

    public static bool poign�etouch�O = false;
    static float Ouverture = 0;
    static float porte = 0;
    public static int porteouverteO= 1;

    public void FermetureOuest()
    {
        if (porteouverteO == -1)
        {
            porteouverteO = -2;
            porte = 0;
            Ouverture = 0;
            poign�etouch�O = true;
        }
    }

    public void OuvertureOuest()
    {
        if (!poign�etouch�O) {
            porte = 0;
            Ouverture = 0;
            poign�etouch�O = true;
        }
        
    }
    void Update()
    {
        if (poign�etouch�O)
        {
            if (porte + Ouverture < 90)
            {
                Ouverture = 40f * Time.deltaTime;
                porte += Ouverture;
                transform.Rotate(0, Ouverture*porteouverteO, 0);
            }
            else
            {
                Ouverture = 90 - porte;
                porte = 0;
                transform.Rotate(0, Ouverture*porteouverteO, 0);
                Ouverture = 0;
                poign�etouch�O = false;
                porteouverteO = porteouverteO==1 ? -1 : 1;
            }


        }
    }
}
            
    
        
        
        
            


