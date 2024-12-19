using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class BloqueCaillou : MonoBehaviour
{
    private GameObject CaillouNord1;
    private GameObject CaillouSud1;
    private GameObject CaillouEst1;
    private GameObject CaillouOuest1;
    private GameObject LaSalle;

    //GameObject LaSalle,bool Nord,bool Sud,bool Est,bool Ouest

    public void PlacementCaillou(List<object> Argument)
    {
        


        GameObject LaSalle = (GameObject)(Argument[0]);

        //Debug.Log(LaSalle);
        
        bool Nord = (bool)(Argument[1]); 
        bool Sud = (bool)(Argument[2]);
        bool Est = (bool)(Argument[3]);
        bool Ouest = (bool)(Argument[4]);

        /*

        if (Nord == null)
        {
            Nord = true;
        }
        if (Sud == null)
        {
            Sud= true;
        }
        if (Est == null)
        {
            Est = true;
        }
        if (Ouest == null)
        {
            Ouest = true;
        }

        */


        //CaillouNord1 = GameObject.FindObjectsOfType<GameObject>().FirstOrDefault(obj => obj.name == "PileRocheNord");
        CaillouNord1 = null;

        foreach (Transform child in LaSalle.transform)
        {
            if (child.name == "PileRocheNord")
            {
                CaillouNord1 = child.gameObject;
            }
        }

        CaillouSud1 = null;

        foreach (Transform child in LaSalle.transform)
        {
            if (child.name == "PileRocheSud")
            {
                CaillouSud1 = child.gameObject;
            }
        }

        CaillouEst1 = null;

        foreach (Transform child in LaSalle.transform)
        {
            if (child.name == "PileRocheEst")
            {
                CaillouEst1 = child.gameObject;
            }
        }

        CaillouOuest1 = null;

        foreach (Transform child in LaSalle.transform)
        {
            if (child.name == "PileRocheOuest")
            {
                CaillouOuest1 = child.gameObject;
            }
        }


        CaillouNord1.SetActive(Nord);

        //CaillouSud1 = GameObject.FindObjectsOfType<GameObject>().FirstOrDefault(obj => obj.name == "PileRocheSud");


        //CaillouSud1 = GameObject.Find("/" + LaSalle.name + "/" + "PileRocheSud");

        CaillouSud1.SetActive(Sud);

        //CaillouEst1 = GameObject.FindObjectsOfType<GameObject>().FirstOrDefault(obj => obj.name == "PileRocheEst");


        //CaillouEst1 = GameObject.Find("/" + LaSalle.name + "/" + "PileRocheEst");

        CaillouEst1.SetActive(Est);

        //CaillouOuest1 = GameObject.FindObjectsOfType<GameObject>().FirstOrDefault(obj => obj.name == "PileRocheOuest");


        //CaillouOuest1 = GameObject.Find("/" + LaSalle.name + "/" + "PileRocheOuest");

        CaillouOuest1.SetActive(Ouest);




    }
}
