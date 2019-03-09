using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageControl : MonoBehaviour {
    [SerializeField]
    private SpriteRenderer player;

    private bool OnDamageTime = false;


    [SerializeField]
    private GameObject Heart;


    // Parte do "Push"
    private Vector2 push;
    [SerializeField]
    private GameObject PlayerController;


    // parte do blink
    public float Timer;

    [SerializeField]
    private int QuantidadeDePiscadas;
    private int Ct = 1;
    private bool Counted = false;

    [SerializeField]
    private float TempoInicialDasPiscadas;
    [SerializeField]
    private float TempoFinalDasPiscadas;


    // desligando o colisor
    [SerializeField]
    private Collider2D PlayerCollider;


    public void Push(Vector2 Valor)
    {
        PlayerController.gameObject.GetComponent<RobotControl>().Push(Valor);
    }

    public void DamageBlink()
    {
        Timer = 0;
        Ct = 1;
        OnDamageTime = true;
        PlayerCollider.enabled = !PlayerCollider.enabled;
        GameObject hrt = Instantiate(Heart);
        hrt.transform.position = new Vector2(transform.position.x, transform.position.y);
        hrt.transform.parent = gameObject.transform;
    }

    // Update is called once per frame
    void Update() {

        if (OnDamageTime)
        {

            Timer += Time.deltaTime;
            if ((Timer <= TempoFinalDasPiscadas) && (Timer <= (TempoInicialDasPiscadas+(TempoFinalDasPiscadas-TempoInicialDasPiscadas)*Ct/(QuantidadeDePiscadas*2+1))) && Timer >= (TempoInicialDasPiscadas + (TempoFinalDasPiscadas - TempoInicialDasPiscadas) *  (Ct-1) / (QuantidadeDePiscadas*2+1)))
            {
                player.color = new Color(player.color.r, player.color.g, player.color.b, 0f);
                Counted = false;
            } else if (Timer <= TempoFinalDasPiscadas)
            {
                player.color = new Color(player.color.r, player.color.g, player.color.b, 1f);
                if ((!Counted) && (Timer <= (TempoInicialDasPiscadas + (TempoFinalDasPiscadas - TempoInicialDasPiscadas) * (Ct+1) / (QuantidadeDePiscadas * 2+1))))
                {
                    Counted = true;
                    Ct+=2;
                }
            }
            else
            {
                player.color = new Color(player.color.r, player.color.g, player.color.b, 1f);
                OnDamageTime = false;
                PlayerCollider.enabled = !PlayerCollider.enabled;
            }


        }
	}
}
