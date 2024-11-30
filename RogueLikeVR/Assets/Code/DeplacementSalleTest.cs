using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementSalleTest : MonoBehaviour
{
    //Déclaration des variables salles (à mettre dans l'inspecteur)

    public GameObject Salle1;
    public GameObject Salle2;
    public GameObject Salle3;
    public GameObject Salle4;

    //Parité de la salle pour éviter des problèmes avec le backtracking

    public static bool SalleActuPaire = true;
    //public static bool Paire = true;

    //Suivi de position de la salle et de la salle précedente

    static int PositionX = 0;
    static int PositionZ = 0;

    static int PositionPrécedenteX = 0;
    static int PositionPrécedenteZ = 0;

    // Variables publiques pour le positionement de la nouvelle salle

    public static int AjoutX = 0;
    public static int AjoutZ = 0;

    // Définition de la liste des salles disponibles, le code en choisis une au hasard

    static List<GameObject> ListeSalles = new List<GameObject>() {};

    //static List<int> MapSalles = new List<int>();

    static List<object> MapSalles = new List<object>();

    static Dictionary<(int, int), int> positionsDict = new Dictionary<(int, int), int>();


    // Définition de la fonction de déplacement d'objets


    public static void MoveGameObject(GameObject A,int X,int Z)
    {
        A.transform.position = new Vector3(X*-33.7484f, -0.5f, Z* -33.7484f);
    }

    // Fonctions directions

    public static void DirectionOuest()
    {
        AjoutZ = 1;
        AjoutX = 0;
    }
    public static void DirectionEst()
    {
        AjoutX = 0;
        AjoutZ = -1;
    }
    public static void DirectionSud()
    {
        AjoutX = -1;
        AjoutZ = 0;
    }
    public static void DirectionNord()
    {
        AjoutX = 1;
        AjoutZ = 0;
    }

    // Définition de la fonction de géneration et placement des salles

    public static void GenerationSalle(bool Paire)
    {
        
        if (SalleActuPaire == Paire)
        {
            Debug.Log("Vrai");

            PositionZ += AjoutZ;
            PositionX += AjoutX;
        }
        else
        {
            Debug.Log("Faux");


            PositionX = PositionPrécedenteX;
            PositionZ = PositionPrécedenteZ;

            PositionX += AjoutX;
            PositionZ += AjoutZ;
        }

        PositionPrécedenteX = PositionX - AjoutX;
        PositionPrécedenteZ = PositionZ - AjoutZ;


        int nombreAleatoire = Random.Range(0, 4);


        if ((PositionZ + PositionX) % 2 == 0)
        {
            SalleActuPaire = true;

            do
            {

              nombreAleatoire = Random.Range(0, 4);
            } while (nombreAleatoire % 2 != 0);
        } 
        else
        {
            SalleActuPaire = false;

            do
            {
                nombreAleatoire = Random.Range(0, 4);
            } while (nombreAleatoire % 2 == 0);
        }

        GameObject NouvelleSalle = ListeSalles[nombreAleatoire];

        /*

        List<int> PositionGenere = new List<int>() { PositionX, PositionZ };

        int Index = MapSalles.IndexOf((List<int>)PositionGenere);

        Debug.Log(MapSalles.Contains((List<int>)PositionGenere));
        */

        GameObject salle;

        /*

        if (Index==-1)
        {
            
            MapSalles.Add(PositionGenere);
            
            Index = MapSalles.IndexOf(PositionGenere);

            Debug.Log(Index);

            MapSalles.Add(new List<object>() { NouvelleSalle, new List<object>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } });
           
            salle = (GameObject)((List<object>)MapSalles[Index+1])[0];


        } else
        {
            Index = MapSalles.IndexOf(PositionGenere);
            salle = (GameObject)((List<object>)MapSalles[Index+1])[0];

        }

        */
        
        var positionKey = (PositionX, PositionZ );

        if (!positionsDict.ContainsKey(positionKey))
        {
            // Add the new position
            positionsDict[positionKey] = MapSalles.Count;

            int index = positionsDict[positionKey];

            Debug.Log(index);
            // Add the new salle and data
            MapSalles.Add(new List<object>() { NouvelleSalle, new List<object>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } });

            salle = (GameObject)((List<object>)MapSalles[index])[0];
        }
        else
        {
            // If the position is already in the dictionary
            int index = positionsDict[positionKey];

            salle = (GameObject)((List<object>)MapSalles[index])[0];
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

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
