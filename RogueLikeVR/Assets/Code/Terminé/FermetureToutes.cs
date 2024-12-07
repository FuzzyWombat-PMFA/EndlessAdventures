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

    private GameObject Torche;

    private List<string> ListeTorches = new List<string>() { "Torche N1", "Torche N2", "Torche E1", "Torche E2", "Torche W1", "Torche W2", "Torche S1", "Torche S2", };

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

    public void AllumageTorches(List<object> Arguments2)
    {
        GameObject LaSalle = (GameObject)(Arguments2[0]);

        Torche = null;

        foreach (Transform child in LaSalle.transform)
        {
            if (child.name == "Torche N1" || child.name == "Torche N2" || child.name == "Torche E1" || child.name == "Torche E2" || child.name == "Torche W1" || child.name == "Torche W2" || child.name == "Torche S1" || child.name == "Torche S2" )
            {
                Torche = child.gameObject;
                Debug.Log(ListeTorches.IndexOf(Torche.name) + 1);
                Torche.SetActive((bool)Arguments2[ListeTorches.IndexOf(Torche.name)+1]);

            }
        }

       




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
