using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PorteRotationSud : MonoBehaviour
{
    private bool poignéetouchéS = false; // Door handle touched state
    //static float Ouverture = 0; // Rotation increment
    private float porte = 270; // Current rotation of the door (starts at 90 degrees)
    private int objectif = 270; // Target rotation for the door (either 90 or 180)
    private int porteouverteS = 1; // Direction of movement (1 = opening, -1 = closing)
    private bool ajusté = true;

    public void FermetureSud()
    {
        //if (porteouverteS == -1)
        //{
            objectif = 270; // Set the target for closing
            porte = 360; // Start the door from 180 degrees (fully opened)
            transform.rotation = Quaternion.Euler(0, 270, 0);
            porteouverteS = 1; // Change direction to open the door
            poignéetouchéS = false;
        //}
    }

    public void OuvertureSud()
    {
        if (!poignéetouchéS)
        {
            if (porteouverteS == -1)
            {
                objectif = 270; // Set the target for opening
                porte = 360; // Start the door from 180 degrees (fully closed)
            }
            else
            {
                objectif = 360; // Set the target for opening
                porte = 270; // Start the door from 90 degrees (fully closed)
            }

            //Ouverture = 0; // Reset the opening increment
            poignéetouchéS = true; // Trigger the opening process
        }
    }
    

    void Update()
    {
        if (poignéetouchéS)
        {
            // Opening the door (porteouverteN == 1)
            if (porteouverteS == 1)
            {
                // Calculate the potential new position for the door
                float newRotation = porte + 100f * Time.deltaTime * porteouverteS;

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
                    poignéetouchéS = false; // Stop the movement
                    porteouverteS = -1; // Change direction to close the door
                    ajusté = true;
                }
            }
            // Closing the door (porteouverteN == -1)
            else if (porteouverteS == -1)
            {
                // Calculate the potential new position for the door
                float newRotation = porte + 100f * Time.deltaTime * porteouverteS;

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
                    poignéetouchéS = false; // Stop the movement
                    porteouverteS = 1; // Change direction to open the door
                    ajusté = true;
                }
            }
        }
        else if (ajusté)
        {
            transform.rotation = Quaternion.Euler(0, objectif, 0);
            ajusté = false;
        }
    }
}
            
    
        
        
        
            


