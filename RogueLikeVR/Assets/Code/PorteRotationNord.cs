using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PorteRotationNord : MonoBehaviour
{

    static bool poignéetouchéN = false;
    static float Ouverture = 0;
    static float porte = 0;
    static int porteouverteN= 1;


    public void OuvertureNord()
    {
        if (!poignéetouchéN) {
            porte = 0;
            Ouverture = 0;
            poignéetouchéN = true;
        }
        
    }
    void Update()
    {
        if (poignéetouchéN)
        {
            if (porte + Ouverture < 90)
            {
                Ouverture = 40f * Time.deltaTime;
                porte += Ouverture;
                transform.Rotate(0, Ouverture*porteouverteN, 0);
            }
            else
            {
                Ouverture = 90 - porte;
                porte = 0;
                transform.Rotate(0, Ouverture*porteouverteN, 0);
                Ouverture = 0;
                poignéetouchéN = false;
                porteouverteN = porteouverteN==1 ? -1 : 1;
            }


        }
    }
}
            
    
        
        
        
            


