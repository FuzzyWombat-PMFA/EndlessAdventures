using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PorteRotationSud : MonoBehaviour
{

    public static bool poignéetouchéS = false;
    static float Ouverture = 0;
    static float porte = 0;
    public static int porteouverteS= 1;

    public void FermetureSud()
    {
        if (porteouverteS==-1)
        {
            porteouverteS = -1;
            porte = 0;
            Ouverture = 0;
            poignéetouchéS = true;
        }
    }

    public void OuvertureSud()
    {
        if (!poignéetouchéS) {
            porte = 0;
            Ouverture = 0;
            poignéetouchéS = true;
        }
        
    }
    void Update()
    {
        if (poignéetouchéS)
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
                poignéetouchéS = false;
                porteouverteS = porteouverteS==1 ? -1 : 1;
            }


        }
    }
}
            
    
        
        
        
            


