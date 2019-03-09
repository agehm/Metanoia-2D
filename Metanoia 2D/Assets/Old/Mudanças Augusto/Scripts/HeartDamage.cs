using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartDamage : MonoBehaviour {

    [SerializeField]
    private bool End;

    [SerializeField]
    private GameObject Audio;



    private void Start()
    {
        Audio = GameObject.FindGameObjectWithTag("AudioManager");
        Audio.gameObject.GetComponent<audioManager>().TakeDamage();
    }
    private void LateUpdate()
    {
        if(End)
        {

            Destroy(gameObject);
    }
    }
}
