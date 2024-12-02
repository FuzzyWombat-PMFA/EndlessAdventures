using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PorteRotationNord : MonoBehaviour
{
    /*
    public static bool poign�etouch�N = false;
    static float Ouverture = 0;
    static float porte = 90;
    static int objectif = 180;
    public static int porteouverteN= 1;

    public void FermetureNord()
    {
        if (porteouverteN == -1)
        {
            objectif = 90;
            porte = 180;
            Ouverture = 0;
            poign�etouch�N = true;
        }
    }

    public void OuvertureNord()
    {
        if (!poign�etouch�N) {
            
            if (porteouverteN == -1)
            {
                objectif = 90;
                porte = 180;
            } else
            {
                objectif = 180;
                porte = 90;
            }
                
            Ouverture = 0;
            poign�etouch�N = true;
        }
        
    }
    void Update()
    {
        if (poign�etouch�N)
        {
            if (porteouverteN == 1)
            {
                if (objectif - porte + 40f * Time.deltaTime * porteouverteN  < 1f)
                {
                    transform.rotation = Quaternion.Euler(0, objectif, 0);
                    poign�etouch�N = false;
                    porteouverteN = porteouverteN == 1 ? -1 : 1;
                }
                else
                {
                    Ouverture = 40f * Time.deltaTime * porteouverteN;

                    porte += Ouverture;

                    transform.rotation = Quaternion.Euler(0, porte, 0);
                }
                
            }
            if (porteouverteN == -1)
            {
                Debug.Log(porte + 40f * Time.deltaTime * porteouverteN - objectif < 1f);

                Debug.Log(porte);

                if (porte + 40f * Time.deltaTime * porteouverteN - objectif < 1f)
                {
                    transform.rotation = Quaternion.Euler(0, objectif, 0);
                    poign�etouch�N = false;
                    porteouverteN = porteouverteN == 1 ? -1 : 1;
                }
                else
                {
                    Ouverture = 40f * Time.deltaTime * porteouverteN;

                    porte += Ouverture;

                    transform.rotation = Quaternion.Euler(0, porte, 0);
                }

            }




        }
    }
    */

    private static bool poign�etouch�N = false; // Door handle touched state
    //static float Ouverture = 0; // Rotation increment
    private static float porte = 90; // Current rotation of the door (starts at 90 degrees)
    private static int objectif = 90; // Target rotation for the door (either 90 or 180)
    private static int porteouverteN = 1; // Direction of movement (1 = opening, -1 = closing)
    private static bool ajust� = true;


    public void FermetureNord()
    {
        //if (porteouverteN == -1)
        //{
        objectif = 90; // Set the target for closing
        porte = 90; // Start the door from 180 degrees (fully opened)
        transform.rotation = Quaternion.Euler(0, 90, 0);
        porteouverteN = 1; // Change direction to open the door
        poign�etouch�N = false;
        //}
    }

    public void OuvertureNord()
    {
        if (!poign�etouch�N)
        {
            if (porteouverteN == -1)
            {
                objectif = 90; // Set the target for opening
                porte = 180; // Start the door from 180 degrees (fully closed)
            }
            else
            {
                objectif = 180; // Set the target for opening
                porte = 90; // Start the door from 90 degrees (fully closed)
            }

            //Ouverture = 0; // Reset the opening increment
            poign�etouch�N = true; // Trigger the opening process
        }
    }

    void Update()
    {
        if (poign�etouch�N)
        {
            // Opening the door (porteouverteN == 1)
            if (porteouverteN == 1)
            {
                // Calculate the potential new position for the door
                float newRotation = porte + 25f * Time.deltaTime * porteouverteN;

                // If we are about to overshoot the target, stop at 'objectif'
                if (newRotation >= objectif)
                {
                    newRotation = objectif; // Set the rotation to the target exactly
                }

                // Apply the rotation
                porte = newRotation;
                transform.rotation = Quaternion.Euler(0, porte, 0);

                // If we've reached the target with a tolerance, stop the movement and change direction
                if (Mathf.Abs(porte - objectif) < 0.1f)
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    poign�etouch�N = false; // Stop the movement
                    porteouverteN = -1; // Change direction to close the door
                    ajust� = true;
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                }
            }
            // Closing the door (porteouverteN == -1)
            else if (porteouverteN == -1)
            {
                // Calculate the potential new position for the door
                float newRotation = porte + 25f * Time.deltaTime * porteouverteN;

                // If we are about to overshoot the target, stop at 'objectif'
                if (newRotation <= objectif)
                {
                    newRotation = objectif; // Set the rotation to the target exactly
                }

                // Apply the rotation
                porte = newRotation;
                transform.rotation = Quaternion.Euler(0, porte, 0);
                
                // If we've reached the target with a tolerance, stop the movement and change direction
                if (Mathf.Abs(porte - objectif) < 0.1f)
                {
                    transform.rotation = Quaternion.Euler(0, 90, 0);
                    poign�etouch�N = false; // Stop the movement
                    porteouverteN = 1; // Change direction to open the door
                    ajust� = true;
                    transform.rotation = Quaternion.Euler(0, 90, 0);
                    transform.rotation = Quaternion.Euler(0, 90, 0);
                    transform.rotation = Quaternion.Euler(0, 90, 0);
                    transform.rotation = Quaternion.Euler(0, 90, 0);
                }
            }
        } else if (ajust�)
        {
            transform.rotation = Quaternion.Euler(0, objectif, 0);
            ajust� = false;
        }

    }
}








