using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueCaillou : MonoBehaviour
{
    private GameObject CaillouNord;
    private GameObject CaillouSud;
    private GameObject CaillouEst;
    private GameObject CaillouOuest;

    private void PlacementCaillou(GameObject LaSalle,bool Nord,bool Sud,bool Est,bool Ouest)
    {


        CaillouNord= GameObject.Find("/" + LaSalle.name + "/" + "PileRocheNord");

        CaillouNord.SetActive(Nord);

        CaillouSud = GameObject.Find("/" + LaSalle.name + "/" + "PileRocheSud");

        CaillouSud.SetActive(Sud);

        CaillouEst = GameObject.Find("/" + LaSalle.name + "/" + "PileRocheEst");

        CaillouEst.SetActive(Est);

        CaillouOuest = GameObject.Find("/" + LaSalle.name + "/" + "PileRocheOuest");

        CaillouOuest.SetActive(Ouest);
    }
}
