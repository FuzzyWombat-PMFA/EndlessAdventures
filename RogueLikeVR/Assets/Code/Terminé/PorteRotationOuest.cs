using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PorteRotationOuest : MonoBehaviour
{

    public static bool poignéetouchéO = false;
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
            poignéetouchéO = true;
        }
    }

    public void OuvertureOuest()
    {
        if (!poignéetouchéO) {
            porte = 0;
            Ouverture = 0;
            poignéetouchéO = true;
        }
        
    }
    void Update()
    {
        if (poignéetouchéO)
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
                poignéetouchéO = false;
                porteouverteO = porteouverteO==1 ? -1 : 1;
            }


        }
    }
}
            
    
        
        
        
            


