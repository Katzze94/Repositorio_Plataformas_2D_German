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

    

    private bool isAttacking;

    private bool isMoving;

    [SerializeField] private Transform attackHitBox;

    [SerializeField] private float attackRadius = 1;
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
        Movement();

       if(Input.GetButtonDown("Jump") && GroundSensor.isGrounded && !isAttacking) //esto es lo mismo que : isAttacking == false
       
       {
            Jump();
       }

        if(Input.GetButtonDown("Fire1") && GroundSensor.isGrounded && !isAttacking)
        {
            Attack();
        }
     }

    // Update is called once per frame
    void FixedUpdate()
    {
        
     characterRigidbody.velocity = new  Vector2(horizontalInput * characterSpeed, characterRigidbody.velocity.y); 
          
    }

    void Movement()
    {
        if(isAttacking && !isMoving) horizontalInput = 0;
        else horizontalInput = Input.GetAxis("Horizontal");

        if(horizontalInput!=0) isMoving=true;
        else isMoving = false;


         //Tambien te puedes ahorra la variable de input de salto poninedo solo en el parentesis de "if" : Input.GetButtonDown("Jump"), esto tambien funciona con otros inputs de botones
        if(horizontalInput < 0)
        {
            if(!isAttacking)
            {
              transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            
            characterAnimator.SetBool("IsRunning", true);
        }
        else if(horizontalInput > 0)
        {
            if(!isAttacking)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            
            characterAnimator.SetBool("IsRunning", true);
        }
        else
        {
            characterAnimator.SetBool("IsRunning", false);
        }
    }


    void Jump()
     {
        characterRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        characterAnimator.SetBool("IsJumping", true);   //no poner punto y coma. "=" asignar valor, "==" comprobar valor //todos los inputs de booleana necesitas un "If"
    }
    


    void Attack()
    {
        StartCoroutine(AttackAnimation());
        if(isMoving) characterAnimator.SetBool("IsRunning", true);
        characterAnimator.SetTrigger("Attack");




    }

    IEnumerator AttackAnimation() //sirver para parar, entre frames
    {
        isAttacking = true;

        yield return new WaitForSeconds(0.2f);
        
        Collider2D[] collider = Physics2D.OverlapCircleAll(attackHitBox.position, attackRadius);
       foreach(Collider2D enemy in collider)

       {
        if(enemy.gameObject.CompareTag("Mimic")) //mejor forma de utilizar los tags
        {
            //Destroy(enemy.gameObject);
            Rigidbody2D enemyRigidbody = enemy.GetComponent<Rigidbody2D>();
            enemyRigidbody.AddForce(transform.right + transform.up * 2, ForceMode2D.Impulse);
            
            Mimic mimic = enemy.GetComponent<Mimic>();

            mimic.TakeDamage();
        }
       }

        yield return new WaitForSeconds(0.5f);
        

        isAttacking = false;
    }
    
  
    void TakeDamage()
    {
        healthPoints--;

        if(healthPoints <= 0) 
        {
            Die();  //resta de 1 en 1 al valor actual
        }

        else 
        {
            characterAnimator.SetTrigger("IsHurt");  
        }
        

        
             
    }
    
    void Die()
    {
        characterAnimator.SetTrigger("IsDead");
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

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackHitBox.position, attackRadius);
    }
}
