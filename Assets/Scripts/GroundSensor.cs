using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
   public static bool isGrounded; //variable estática , nos ahorramos crear otras varaibles, siempre son publicas y son globalmente accesibles. Tienen un inconveniente, se comparte en los scripts. Tendran el mismo valor
   


   void OnTriggerEnter2D(Collider2D collider) //dentro de parentesis se llama parametro

   {

        if(collider.gameObject.layer == 6)
        {
            isGrounded = true;
        }
   
   }
        
    void OnTriggerStay2D(Collider2D collider)

    {
       if(collider.gameObject.layer == 6)
        {
            isGrounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    
    {
        if(collider.gameObject.layer == 6)
        {
            isGrounded = false;
        }
    }

}




