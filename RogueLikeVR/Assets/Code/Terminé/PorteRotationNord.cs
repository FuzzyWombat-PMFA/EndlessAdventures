using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PorteRotationNord : MonoBehaviour
{

    private bool poignéetouchéN = false; // Door handle touched state
    //static float Ouverture = 0; // Rotation increment
    private float porte = 90; // Current rotation of the door (starts at 90 degrees)
    private int objectif = 90; // Target rotation for the door (either 90 or 180)
    private int porteouverteN = 1; // Direction of movement (1 = opening, -1 = closing)
    private bool ajusté = true;


    private void FermetureNord()
    {
        //if (porteouverteN == -1)
        //{
        objectif = 90; // Set the target for closing
        porte = 90; // Start the door from 180 degrees (fully opened)
        transform.rotation = Quaternion.Euler(0, 90, 0);
        porteouverteN = 1; // Change direction to open the door
        poignéetouchéN = false;
        //}
    }

    private void OuvertureNord()
    {
        if (!poignéetouchéN)
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
            poignéetouchéN = true; // Trigger the opening process
        }
    }

    void Update()
    {
        if (poignéetouchéN)
        {
            
            // Opening the door (porteouverteN == 1)
            if (porteouverteN == 1)
            {
                // Calculate the potential new position for the door
                float newRotation = porte + 100f * Time.deltaTime * porteouverteN;

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
                    poignéetouchéN = false; // Stop the movement
                    porteouverteN = -1; // Change direction to close the door
                    ajusté = true;
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                }
            }
            // Closing the door (porteouverteN == -1)
            else if (porteouverteN == -1)
            {
                // Calculate the potential new position for the door
                float newRotation = porte + 100f * Time.deltaTime * porteouverteN;

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
                    poignéetouchéN = false; // Stop the movement
                    porteouverteN = 1; // Change direction to open the door
                    ajusté = true;
                    transform.rotation = Quaternion.Euler(0, 90, 0);
                    transform.rotation = Quaternion.Euler(0, 90, 0);
                    transform.rotation = Quaternion.Euler(0, 90, 0);
                    transform.rotation = Quaternion.Euler(0, 90, 0);
                }
            }
        } else if (ajusté)
        {
            transform.rotation = Quaternion.Euler(0, objectif, 0);
            ajusté = false;
        }

    }
}








