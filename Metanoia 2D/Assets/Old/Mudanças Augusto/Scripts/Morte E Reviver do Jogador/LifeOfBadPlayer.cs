using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeOfBadPlayer : MonoBehaviour
{
    public float life;

    


    public void dano(float amount)
    {
        life += amount;
        if(gameObject.tag == "BadPlayer")
        {
            // ----------------------------   <<<<<<< Ativa a piscada do player >>>>>>>>>> ----------------------------------------
            gameObject.GetComponent<TakeDamageControl>().DamageBlink();



            if (life > 100)
            {
                GameObject plr = GameObject.FindGameObjectWithTag("Player");
                if (plr)
                {
                    Destroy(gameObject);
                }
                else
                {
                    EndOfPlayer();
                }
            }
        }
        else
        {
            if (life > 100)
            {

                    Destroy(gameObject);
                }
            }



    }

    public void EndOfPlayer()
    {
        gameObject.GetComponent<BadPlayer>().BadPlayerDefeated();
    }
}
