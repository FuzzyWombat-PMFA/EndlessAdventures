using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq; // For LINQ (e.g., FirstOrDefault)

public class FermetureToutes : MonoBehaviour
{
    private GameObject CaillouNord;
    private GameObject CaillouSud;
    private GameObject CaillouEst;
    private GameObject CaillouOuest;

    private GameObject PorteNord;
    private GameObject PorteSud;
    private GameObject PorteEst;
    private GameObject PorteOuest;

    public void ResetCaillou(GameObject LaSalle)
    {
        CaillouNord = null;

        foreach (Transform child in LaSalle.transform)
        {
            if (child.name == "PileRocheNord")
            {
                CaillouNord = child.gameObject;
            }
        }

        CaillouSud = null;

        foreach (Transform child in LaSalle.transform)
        {
            if (child.name == "PileRocheSud")
            {
                CaillouSud = child.gameObject;
            }
        }

        CaillouEst = null;

        foreach (Transform child in LaSalle.transform)
        {
            if (child.name == "PileRocheEst")
            {
                CaillouEst = child.gameObject;
            }
        }

        CaillouOuest = null;

        foreach (Transform child in LaSalle.transform)
        {
            if (child.name == "PileRocheOuest")
            {
                CaillouOuest = child.gameObject;
            }
        }
        /*
        CaillouNord = GameObject.FindObjectsOfType<GameObject>().FirstOrDefault(obj => obj.name == "PileRocheNord");

        CaillouSud = GameObject.FindObjectsOfType<GameObject>().FirstOrDefault(obj => obj.name == "PileRocheSud");

        CaillouEst = GameObject.FindObjectsOfType<GameObject>().FirstOrDefault(obj => obj.name == "PileRocheEst");

        CaillouOuest = GameObject.FindObjectsOfType<GameObject>().FirstOrDefault(obj => obj.name == "PileRocheOuest");
        */

        //CaillouNord = GameObject.Find("/" + LaSalle.name + "/" + "PileRocheNord");

        CaillouNord.SetActive(false);

        //CaillouSud = GameObject.Find("/" + LaSalle.name + "/" + "PileRocheSud");

        CaillouSud.SetActive(false);

        //CaillouEst = GameObject.Find("/" + LaSalle.name + "/" + "PileRocheEst");

        CaillouEst.SetActive(false);

        //CaillouOuest = GameObject.Find("/" + LaSalle.name + "/" + "PileRocheOuest");

        CaillouOuest.SetActive(false);

        


    }


    public void Fermetout(GameObject LaSalle)
    {

        PorteNord = GameObject.Find("/"+LaSalle.name + "/" + "PorteNORD"); 
        PorteSud = GameObject.Find("/" + LaSalle.name+"/" + "PorteSUD");
        PorteEst = GameObject.Find("/"+LaSalle.name + "/" + "PorteEST");
        PorteOuest = GameObject.Find("/"+LaSalle.name + "/" + "PorteOUEST");

        PorteNord.SendMessage("FermetureNord");
        PorteSud.SendMessage("FermetureSud");
        PorteEst.SendMessage("FermetureEst");
        PorteOuest.SendMessage("FermetureOuest");

        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
