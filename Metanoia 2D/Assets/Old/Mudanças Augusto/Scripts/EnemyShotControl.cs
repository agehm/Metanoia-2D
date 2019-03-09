using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotControl : MonoBehaviour
{
    public bool MoveLeftToRight;
    public float Speed;
    public float Damage = -20f;




    void Start()
    {
        Destroy(gameObject, 10);
    }

    void Update()
    {
        if (MoveLeftToRight)
            transform.Translate(Speed * Time.deltaTime, 0, 0);
        else
            transform.Translate(-Speed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
         if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<LifeOfObject>().dano(Damage);


            //---------------------- <<<<<< parte pra determinar o empurrão >>>>>>>>>> -----------------------------------

            var magnitude = 1500;

            var force = transform.position - other.transform.position;

            force.Normalize();
            other.gameObject.GetComponent<TakeDamageControl>().Push(-force * magnitude);
       }

        Destroy(gameObject);
        if (other.gameObject.tag == "BadPlayer")
        {
            other.gameObject.GetComponent<LifeOfBadPlayer>().dano(Damage);


            //---------------------- <<<<<< parte pra determinar o empurrão >>>>>>>>>> -----------------------------------


        }



    }
}
