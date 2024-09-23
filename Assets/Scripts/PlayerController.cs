using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D characterRigidbody;

    public static Animator characterAnimator;

    private float horizontalInput;

    [SerializeField] private int healthPoints = 3;

    [SerializeField] private float characterSpeed = 4.5f;  //"f" para que el numero se entienda el float y solo si es decimal sino no hace falta

    [SerializeField] private float jumpForce = 10;
    // [SerializeField]:Para que las variables privadas salgan en el inspector
    // Start is called before the first frame update
   
   void Awake()
    {
        characterRigidbody = GetComponent<Rigidbody2D>();
        characterAnimator = GetComponent<Animator>();
    }
    
    void Start()
    {
        //characterRigidbody.AddForce(Vector2.up * jumpForce); //si lo que después del punto es minuscula es igual, si es mayúscula es parentesis
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

         //Tambien te puedes ahorra la variable de input de salto poninedo solo en el parentesis de "if" : Input.GetButtonDown("Jump"), esto tambien funciona con otros inputs de botones
        if(horizontalInput < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            characterAnimator.SetBool("IsRunning", true);
        }
        else if(horizontalInput > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            characterAnimator.SetBool("IsRunning", true);
        }
        else
        {
            characterAnimator.SetBool("IsRunning", false);
        }
        
        
        
        if(Input.GetButtonDown("Jump") && GroundSensor.isGrounded) //no poner punto y coma. "=" asignar valor, "==" comprobar valor //todos los inputs de booleana necesitas un "If"
        {
            characterRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            characterAnimator.SetBool("IsJumping", true);
        }

    
   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        characterRigidbody.velocity = new  Vector2(horizontalInput * characterSpeed, characterRigidbody.velocity.y); 
    }


    
    void TakeDamage()
    {
        healthPoints--;

        if(healthPoints == 0) Die();
        
        characterAnimator.SetTrigger("IsHurt");  //resta de 1 en 1 al valor actual
       
        
             
    }
    
    void Die()
    {
        characterAnimator.SetBool("IsDead", true);
        Destroy(gameObject, 0.47f);
    }
    
    
     void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            TakeDamage();
        
            //characterAnimator.SetTrigger("IsHurt");
           // Destroy(gameObject, 0.48f);
        }
    }
}
