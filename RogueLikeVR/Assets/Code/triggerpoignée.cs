using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class triggerpoignée : MonoBehaviour
{
    public UnityEvent OnEnterTrigger;

    //private Collider _collider;
    //private void Awake()
    //{
    //   _collider = GetComponent<Collider>();
    //_collider.isTrigger = true;
    //}

    [Header ("Filters")]
    [SerializeField]
    private GameObject _objetspécifique = null;





    private void OnTriggerEnter(Collider other) 
    {
        if(_objetspécifique != null && other.gameObject != _objetspécifique) return;
        

        Debug.Log("Entrée");
        OnEnterTrigger.Invoke();
    }
    
}
