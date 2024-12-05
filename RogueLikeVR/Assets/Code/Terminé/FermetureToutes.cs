using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
        CaillouNord = GameObject.Find("/" + LaSalle.name + "/" + "PileRocheNord");

        CaillouNord.SetActive(true);

        CaillouSud = GameObject.Find("/" + LaSalle.name + "/" + "PileRocheSud");

        CaillouSud.SetActive(true);

        CaillouEst = GameObject.Find("/" + LaSalle.name + "/" + "PileRocheEst");

        CaillouEst.SetActive(true);

        CaillouOuest = GameObject.Find("/" + LaSalle.name + "/" + "PileRocheOuest");

        CaillouOuest.SetActive(true);
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
