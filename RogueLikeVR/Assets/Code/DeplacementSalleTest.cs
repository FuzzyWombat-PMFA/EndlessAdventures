using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;


public class DeplacementSalleTest : MonoBehaviour
{
    //Déclaration des variables salles (à mettre dans l'inspecteur)

    public GameObject Joueur;

    public GameObject Salle1;
    public GameObject Salle2;
    public GameObject Salle3;
    public GameObject Salle4;

    //Event UnityReset


    //Parité de la salle pour éviter des problèmes avec le backtracking

    public static bool SalleActuPaire = true;
    //public static bool Paire = true;

    //Suivi de position de la salle et de la salle précedente

    static int PositionX = 0;
    static int PositionZ = 0;

    public static double PosXTest = 0;
    public static double PosZTest = 0;


    //static int PositionPrécedenteX = 0;
    //static int PositionPrécedenteZ = 0;

    // Variables publiques pour le positionement de la nouvelle salle

    public static int AjoutX = 0;
    public static int AjoutZ = 0;

    // Définition de la liste des salles disponibles, le code en choisis une au hasard

    static List<GameObject> ListeSalles = new List<GameObject>() {};

    static int NombreSalles = 4;

    //static List<int> MapSalles = new List<int>();

    static List<object> MapSalles = new List<object>();

    static Dictionary<(int, int), int> positionsDict = new Dictionary<(int, int), int>();

    
// Définition de la fonction de déplacement d'objets


public static void MoveGameObject(GameObject A,int X,int Z)
    {
        A.transform.position = new Vector3(X*-33.75f, -0.5f, Z* -33.75f);
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
        
        /*
        
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

        */
        GameObject JoueurObjet= GameObject.Find("Camera Offset");

        //10.875
        
        PosXTest = (JoueurObjet.transform.position.x-10.875)/33.75f;
        PosZTest = (JoueurObjet.transform.position.z-10.875)/33.75f;

        PositionX = -(int)System.Math.Round(PosXTest) + AjoutX;
        PositionZ = -(int)System.Math.Round(PosZTest) + AjoutZ;

        
        int nombreAleatoire = Random.Range(0, NombreSalles);


        if ((PositionZ + PositionX) % 2 == 0)
        {
            SalleActuPaire = true;

            do
            {

                nombreAleatoire = Random.Range(0, NombreSalles);
            } while (nombreAleatoire % 2 != 0);
        }
        else
        {
            SalleActuPaire = false;

            do
            {
                nombreAleatoire = Random.Range(0, NombreSalles);
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

        var positionKey = (PositionX, PositionZ);
        /*
            if (!positionsDict.ContainsKey(positionKey))
            {
                // Add the new position
                positionsDict[positionKey] = MapSalles.Count;

                int index = positionsDict[positionKey];

                nombreAleatoire = Random.Range(0, 4);

                List<bool> Caillous = new List<bool>() { };

                if (nombreAleatoire > 0)
                {
                for (int i = 0; i < nombreAleatoire; i++)
                {
                    Caillous.Add(Random.Range(0, 2) == 1 ? true : false);
                }
                for (int i = 0; i < 4 - nombreAleatoire; i++)
                {
                    Caillous.Add(true);
                }
                }
            





                // Add the new salle and data
                MapSalles.Add(new List<object>() { NouvelleSalle, new List<object>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, Caillous });
                
                

                salle = (GameObject)((List<object>)MapSalles[index])[0];
            }
            else
            {
                // If the position is already in the dictionary
                 
                int index = positionsDict[positionKey];

                salle = (GameObject)((List<object>)MapSalles[index])[0];

                 List <bool> Caillous = (List<bool>)((List<object>)MapSalles[index])[3];

            }



            salle.SendMessage("Fermetout",salle);

            if (salle == ListeSalles[0])
            {
                Debug.Log("OhShit");
            }

            salle.SendMessage("ResetCaillou",salle);

            salle.SendMessage("PlacementCaillou", salle, Caillous[0], Caillous[1], Caillous[2], Caillous[3]); 

            Debug.Log(PositionX+" "+PositionZ);

            MoveGameObject(salle, PositionX, PositionZ);
        */


        List<bool> Caillous = new List<bool>() { };

        if (!positionsDict.ContainsKey(positionKey))
        {
            positionsDict[positionKey] = MapSalles.Count;
            int index = positionsDict[positionKey];
            nombreAleatoire = Random.Range(0, 4);
            
            if (nombreAleatoire > 0)
            {
                
                for (int i = 0; i < nombreAleatoire; i++)
                {
                    if(Random.Range(0, 2) == 1)
                    {
                        Caillous.Add(false);
                    }
                    else
                    {
                        Caillous.Add(true);
                    }
                    
                }
                
                for (int i = 0; i < 4 - nombreAleatoire; i++)
                {
                    Caillous.Add(false);
                }
                
            }

            else
            {
                Caillous.Add(false);
                Caillous.Add(false);
                Caillous.Add(false);
                Caillous.Add(false);
            }
            
            MapSalles.Add(new List<object>() { NouvelleSalle, new List<object>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, Caillous });
            salle = (GameObject)((List<object>)MapSalles[index])[0];
        }

        else
        {
            int index = positionsDict[positionKey];
            salle = (GameObject)((List<object>)MapSalles[index])[0];
            Debug.Log(index);
            Caillous = (List<bool>)((List<object>)MapSalles[index])[2];
        }

        salle.SendMessage("Fermetout", salle);


        //salle.SendMessage("PlacementCaillou", salle);

        //salle.SendMessage("ResetCaillou", salle);

        Caillous.Add(false);
        Caillous.Add(false);
        Caillous.Add(false);
        Caillous.Add(false);


        List<object> Arguments = new List<object>() {salle, Caillous[0], Caillous[1], Caillous[2], Caillous[3] };

        Debug.Log(Arguments);

        salle.SendMessage("PlacementCaillou", Arguments);


        Debug.Log(PositionX + " " + PositionZ);
        MoveGameObject(salle, PositionX, PositionZ);
    }

    // Start is called before the first frame update
    void Start()
    {
        
        ListeSalles.Add(Salle1);
        ListeSalles.Add(Salle2);
        ListeSalles.Add(Salle3);
        ListeSalles.Add(Salle4);
        positionsDict[(0,0)] = MapSalles.Count;

        MapSalles.Add(new List<object>() { Salle1, new List<object>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new List<bool>() { false, false, false, false } });

    }

}
