using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapePlayerLives : MonoBehaviour {

    [SerializeField]
    private bool End;

    private GameObject GameManager;
    [SerializeField]
    private GameObject Hero;

    private void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    /*
[SerializeField]
private GameObject Audio;



private void Start()
{

Audio = GameObject.FindGameObjectWithTag("AudioManager");
Audio.gameObject.GetComponent<audioManager>().TakeDamage();

}
*/
    private void LateUpdate()
    {
        if(End)
        {
            GameObject Hr = Instantiate(Hero) as GameObject;
            Hr.transform.position = new Vector2(transform.parent.position.x, transform.parent.position.y);
            GameManager.GetComponent<GameManager>().PlayerIsAlive(Hr.transform);
            Destroy(gameObject.transform.parent.gameObject);
    }
    }
}
