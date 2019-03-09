using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {
    [SerializeField]
    private GameObject GameManager;

    [SerializeField]
    private float DistanciaDeAjusteY = -0.82f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.gameObject.GetComponent<GameManager>().CheckPointSpot(transform.parent.position.x, transform.parent.position.y - DistanciaDeAjusteY);
    }
}

