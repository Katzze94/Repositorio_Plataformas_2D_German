using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    
    private bool interactable;
    
    
     void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
          GameManager.instance.Addstar();
           Destroy(gameObject, 0.1f);
        }
    }


}
