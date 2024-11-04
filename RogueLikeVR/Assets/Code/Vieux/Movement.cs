using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5;
    void Start()
    {
        Debug.Log("Message");
    }

    void Update()
    {

        float speed = 5;
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(x, 0, z);
        //Debug.Log(x);
        //Debug.Log(y);
        //Debug.Log(movement);
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
