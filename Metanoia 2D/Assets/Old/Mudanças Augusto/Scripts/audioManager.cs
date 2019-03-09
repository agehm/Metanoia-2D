using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour {

    [SerializeField]
    private AudioSource Audio;
    [SerializeField]
    private AudioClip TakeDamageClip;


	public void TakeDamage()
    {
        Audio.PlayOneShot(TakeDamageClip);
    }
}
