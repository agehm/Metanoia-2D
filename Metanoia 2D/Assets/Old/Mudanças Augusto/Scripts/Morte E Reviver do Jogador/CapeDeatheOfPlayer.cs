using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapeDeatheOfPlayer : MonoBehaviour {

    [SerializeField]
    private bool End;

    private GameObject GameManager;

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
            GameManager.GetComponent<GameManager>().PlayerDeath();
            GameManager.GetComponent<GameManager>().BadPlayer(gameObject.transform.parent.gameObject);

            Destroy(gameObject);
    }
    }
}
