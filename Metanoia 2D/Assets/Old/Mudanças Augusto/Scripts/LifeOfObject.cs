using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeOfObject : MonoBehaviour
{
    public float life;
    public GameObject Player;

    [SerializeField]
    private GameObject BadHero;


    private GameObject GameManager;

    public void dano(float amount)
    {
        life += amount;

        // ----------------------------   <<<<<<< Ativa a piscada do player >>>>>>>>>> ----------------------------------------

            Player.gameObject.GetComponent<TakeDamageControl>().DamageBlink();

        if (gameObject.tag == "Player" || gameObject.tag == "AnotherPlayer")
        {

            if (life <= 0)
            {
                EndOfPlayer();
            }
            else if (life > 100)
            {
                life = 100;
            }


        }
    }

    public void Gamemanager(GameObject GameManagerNew)
    {
        GameManager = GameManagerNew;
    }

    public void EndOfPlayer()
    {
        float x = transform.position.x;
        float y = transform.position.y;

        GameObject BdH = Instantiate(BadHero) as GameObject;
        if(gameObject.tag == "Player")
        {
            BdH.transform.position = new Vector2(x, y);
        }
        else
        {
            GameManager.GetComponent<GameManager>().PlayerDeath();
            BdH.transform.position = new Vector2(x, y);
        }


        if(gameObject.tag == "Player")
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        //SceneManager.LoadScene("GameOver");
    }
}
