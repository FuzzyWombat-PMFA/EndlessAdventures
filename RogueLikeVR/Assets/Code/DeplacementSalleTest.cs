using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementSalleTest : MonoBehaviour
{
    GameObject gameObjectToMove;

    public void MoveGameObject()
    {
        transform.position = new Vector3(-33.7484f, -0.5f, 0);
    }
    // Start is called before the first frame update
    void Start()
    {
        MoveGameObject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
