using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementSalleTest : MonoBehaviour
{
    public GameObject Salle1;
    public GameObject Salle2;
    public GameObject Salle3;
    public GameObject Salle4;
    
    static int PositionX = 0;
    static int PositionZ = 0;


    static List<GameObject> ListeSalles = new List<GameObject>();

    //static List<int> MapSalles = new List<int>();
    static List<object> MapSalles = new List<object>();




    public static void MoveGameObject(GameObject A,int X,int Z)
    {
        A.transform.position = new Vector3(X*-33.7484f, -0.5f, Z* -33.7484f);
    }

    public static void GenerationSalleOuest()
    {

        PositionZ = PositionZ + 1;


        int nombreAleatoire = Random.Range(0, 4);


        if ((PositionZ + PositionX) % 2 == 0)
        {
            do
            {
                nombreAleatoire = Random.Range(0, 4);
            } while (nombreAleatoire % 2 != 0);
        } 
        else
        {
            do
            {
                nombreAleatoire = Random.Range(0, 4);
            } while (nombreAleatoire % 2 == 0);
        }

        GameObject NouvelleSalle = ListeSalles[nombreAleatoire];


        List<int> PositionGenere = new List<int>() {PositionX,PositionZ};

        int Index = MapSalles.IndexOf(PositionGenere);

        GameObject salle;

        if (Index==-1)
        {
            MapSalles.Add(new List<int>() { PositionX, PositionZ });
            MapSalles.Add(new List<object>() { NouvelleSalle, new List<object>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } });
            salle = (GameObject)((List<object>)MapSalles[1])[0];


        } else
        {
            Index = MapSalles.IndexOf(PositionGenere);
            salle = (GameObject)((List<object>)MapSalles[Index+1])[0];

        }
        MoveGameObject(salle,PositionX,PositionZ);
    }

    // Start is called before the first frame update
    void Start()
    {
        
        ListeSalles.Add(Salle1);
        ListeSalles.Add(Salle2);
        ListeSalles.Add(Salle3);
        ListeSalles.Add(Salle4);

        GenerationSalleOuest();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
