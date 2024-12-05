using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PorteRotationOuest : MonoBehaviour
{
    private bool poign�etouch�O = false; // Door handle touched state
    //static float Ouverture = 0; // Rotation increment
    private float porte = 0; // Current rotation of the door (starts at 90 degrees)
    private int objectif = 0; // Target rotation for the door (either 90 or 180)
    private int porteouverteO = 1; // Direction of movement (1 = opening, -1 = closing)
    private bool ajust� = true;

    public void FermetureOuest()
    {
        //if (porteouverteO == -1)
        //{
            objectif = 0; // Set the target for closing
            porte = 90; // Start the door from 180 degrees (fully opened)
            transform.rotation = Quaternion.Euler(0, 0, 0);
            porteouverteO = 1; // Change direction to open the door
            poign�etouch�O = false;
        //}
    }

    public void OuvertureOuest()
    {
        if (!poign�etouch�O)
        {
            if (porteouverteO == -1)
            {
                objectif = 0; // Set the target for opening
                porte = 90; // Start the door from 180 degrees (fully closed)
            }
            else
            {
                objectif = 90; // Set the target for opening
                porte = 0; // Start the door from 90 degrees (fully closed)
            }

            //Ouverture = 0; // Reset the opening increment
            poign�etouch�O = true; // Trigger the opening process
        }
    }
    

    void Update()
    {
        if (poign�etouch�O)
        {
            // Opening the door (porteouverteN == 1)
            if (porteouverteO == 1)
            {
                // Calculate the potential new position for the door
                float newRotation = porte + 100f * Time.deltaTime * porteouverteO;

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
                    poign�etouch�O = false; // Stop the movement
                    porteouverteO = -1; // Change direction to close the door
                    ajust� = true;
                }
            }
            // Closing the door (porteouverteN == -1)
            else if (porteouverteO == -1)
            {
                // Calculate the potential new position for the door
                float newRotation = porte + 100f * Time.deltaTime * porteouverteO;

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
                    poign�etouch�O = false; // Stop the movement
                    porteouverteO = 1; // Change direction to open the door
                    ajust� = true;
                }
            }
        }
        else if (ajust�)
        {
            transform.rotation = Quaternion.Euler(0, objectif, 0);
            ajust� = false;
        }
    }
}
            
    
        
        
        
            


