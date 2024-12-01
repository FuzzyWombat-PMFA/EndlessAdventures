using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PorteRotationEst : MonoBehaviour
{
    public static bool poign�etouch�E = false; // Door handle touched state
    //static float Ouverture = 0; // Rotation increment
    static float porte = 180; // Current rotation of the door (starts at 90 degrees)
    static int objectif = 180; // Target rotation for the door (either 90 or 180)
    public static int porteouverteE = 1; // Direction of movement (1 = opening, -1 = closing)
    static bool ajust� = true;

    public void FermetureEst()
    {
        if (porteouverteE == -1)
        {
            objectif = 180; // Set the target for closing
            porte = 270; // Start the door from 180 degrees (fully opened)
            transform.rotation = Quaternion.Euler(0, 180, 0);
            porteouverteE = 1; // Change direction to open the door
        }
    }

    public void OuvertureEst()
    {
        if (!poign�etouch�E)
        {
            if (porteouverteE == -1)
            {
                objectif = 180; // Set the target for opening
                porte = 270; // Start the door from 180 degrees (fully closed)
            }
            else
            {
                objectif = 270; // Set the target for opening
                porte = 180; // Start the door from 90 degrees (fully closed)
            }

            //Ouverture = 0; // Reset the opening increment
            poign�etouch�E = true; // Trigger the opening process
        }
    }

    void Update()
    {
        if (poign�etouch�E)
        {
            // Opening the door (porteouverteN == 1)
            if (porteouverteE == 1)
            {
                // Calculate the potential new position for the door
                float newRotation = porte + 25f * Time.deltaTime * porteouverteE;

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
                    poign�etouch�E = false; // Stop the movement
                    porteouverteE = -1; // Change direction to close the door
                    ajust� = true;
                }
            }
            // Closing the door (porteouverteN == -1)
            else if (porteouverteE == -1)
            {
                // Calculate the potential new position for the door
                float newRotation = porte + 25f * Time.deltaTime * porteouverteE;

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
                    poign�etouch�E = false; // Stop the movement
                    porteouverteE = 1; // Change direction to open the door
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
            
    
        
        
        
            


