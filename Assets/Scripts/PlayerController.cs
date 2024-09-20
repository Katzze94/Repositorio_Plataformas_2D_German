using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D characterRigidbody;

    private float horizontalInput;

   

    [SerializeField] private float characterSpeed = 4.5f;  //"f" para que el numero se entienda el float y solo si es decimal sino no hace falta

    [SerializeField] private float jumpForce = 10;



    // [SerializeField]:Para que las variables privadas salgan en el inspector
    // Start is called before the first frame update
   
   void Awake()
    {
        characterRigidbody = GetComponent<Rigidbody2D>();
    }
        
    
   
    void Start()
    {
        //characterRigidbody.AddForce(Vector2.up * jumpForce); //si lo que después del punto es minuscula es igual, si es mayúscula es parentesis
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

         //Tambien te puedes ahorra la variable de input de salto poninedo solo en el parentesis de "if" : Input.GetButtonDown("Jump")

        if(Input.GetButtonDown("Jump")) //no poner punto y coma, "=" asignar valor, "==" comprobar valor //todos los inputs de booleana necesitas un "If"
        {
            characterRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        characterRigidbody.velocity = new  Vector2(horizontalInput * characterSpeed, characterRigidbody.velocity.y); 
    }
}
