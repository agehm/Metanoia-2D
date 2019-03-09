using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpRobot : MonoBehaviour
{
    [SerializeField]
    private Transform positionToWarp;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.position = positionToWarp.position;
    }

}
