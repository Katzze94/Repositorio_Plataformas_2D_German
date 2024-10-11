using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mimic : MonoBehaviour
{
   
   private Rigidbody2D enemyRigidbody;
   [SerializeField] private int mimicHealthPoints = 3;

   private AudioSource _audioSource;

   
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SoundManager.instance.PlaySFX(_audioSource, SoundManager.instance.mimicAudio);
    }

    void Awake()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
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
