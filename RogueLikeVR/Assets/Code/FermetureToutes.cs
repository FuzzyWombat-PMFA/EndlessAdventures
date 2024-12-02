using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FermetureToutes : MonoBehaviour
{
    private GameObject PorteNord;
    private GameObject PorteSud;
    private GameObject PorteEst;
    private GameObject PorteOuest;

    public void Fermetout(GameObject LaSalle)
    {
        Debug.Log("/" + LaSalle.name + "/" + "PorteNORD");

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
