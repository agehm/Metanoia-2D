using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buraco : MonoBehaviour
{

    public float Damage = -200f;






    private void OnTriggerEnter2D(Collider2D other)
    {
         if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<LifeOfObject>().dano(Damage);


 
       }
         
        if (other.gameObject.tag == "BadPlayer")
        {
            other.gameObject.GetComponent<LifeOfBadPlayer>().dano(Damage);


            //---------------------- <<<<<< parte pra determinar o empurrão >>>>>>>>>> -----------------------------------


        }


        if (other.gameObject.tag == "AnotherPlayer")
        {

            other.gameObject.GetComponent<LifeOfObject>().dano(Damage);
        }


    }
}
