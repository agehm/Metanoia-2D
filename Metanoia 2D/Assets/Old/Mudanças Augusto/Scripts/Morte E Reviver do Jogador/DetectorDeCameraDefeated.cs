using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorDeCameraDefeated : MonoBehaviour {
    [SerializeField]
    private Transform BadPlayerChangerPosition;
    [SerializeField]
    private GameManager GameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
            GameManager.GetComponent<GameManager>().CameraOfDefeatedPlayerCollision(BadPlayerChangerPosition);
    }
}
