using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointGoBack : MonoBehaviour {
    [SerializeField]
    private GameObject GameManager;

    [SerializeField]
    private float DistanciaDeAjusteY = -0.82f;

    [SerializeField]
    private GameObject PontoAnterior;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.gameObject.GetComponent<GameManager>().CheckPointSpot(PontoAnterior.gameObject.transform.position.x, PontoAnterior.gameObject.transform.position.y - DistanciaDeAjusteY);
    }
}

