using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PorteRotationEst : MonoBehaviour
{

    public static bool poign�etouch�E = false;
    static float Ouverture = 0;
    static float porte = 0;
    public static int porteouverteE= 1;

    public void FermetureEst()
    {
        if (porteouverteE == -1)
        {
            porteouverteE = -1;
            porte = 0;
            Ouverture = 0;
            poign�etouch�E = true;
        }
    }

    public void OuvertureEst()
    {
        if (!poign�etouch�E) {
            porte = 0;
            Ouverture = 0;
            poign�etouch�E = true;
        }
        
    }
    void Update()
    {
        if (poign�etouch�E)
        {
            if (porte + Ouverture < 90)
            {
                Ouverture = 40f * Time.deltaTime;
                porte += Ouverture;
                transform.Rotate(0, Ouverture*porteouverteE, 0);
            }
            else
            {
                Ouverture = 90 - porte;
                porte = 0;
                transform.Rotate(0, Ouverture*porteouverteE, 0);
                Ouverture = 0;
                poign�etouch�E = false;
                porteouverteE = porteouverteE==1 ? -1 : 1;
            }


        }
    }
}
            
    
        
        
        
            


