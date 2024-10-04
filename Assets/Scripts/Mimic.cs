using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mimic : MonoBehaviour
{
   
   private Rigidbody2D enemyRigidbody;
   [SerializeField] private int mimicHealthPoints = 3;
   
   
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
    }


    public void TakeDamage()
    {
        mimicHealthPoints--;

        if(mimicHealthPoints <= 0) 
        {
            Die();  //resta de 1 en 1 al valor actual
        }
    }

     void Die()
    {
        Destroy(gameObject);
    }
}
