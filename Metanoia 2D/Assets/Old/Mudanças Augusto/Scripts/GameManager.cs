using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private Transform PontoInicial;
    
    private Transform Ponto;

    private bool PlayerIsDefeated = false;

    [SerializeField]
    private GameObject SemCapa;

    [SerializeField]
    private GameObject Bus;

    [SerializeField]
    private GameObject Camera;

    private GameObject Plr;
    private GameObject Bs;
    private void Start()
    {
        Ponto = PontoInicial;
    }

    private GameObject BdPlr;

    // -------------------------- Controle da morte do jogador e respawn do novo jogador -----------------------------------------

    public void PlayerDeath()
    {
        PlayerIsDefeated = true;
        Plr = Instantiate(SemCapa) as GameObject;
        Plr.transform.position = new Vector2(Ponto.position.x, Ponto.position.y);
        Plr.GetComponent<LifeOfObject>().Gamemanager(gameObject);
        Camera.GetComponent<CameraFollowing>().ChangeTarget(Plr.transform);

        Bs = Instantiate(Bus) as GameObject;
        Bs.transform.position = new Vector2(Ponto.position.x, Ponto.position.y);

    }

    public void BadPlayer(GameObject BadPlayer)
    {
        BdPlr = BadPlayer;
    }



    public void PlayerIsAlive(Transform Hero)
    {
        PlayerIsDefeated = false;
        Camera.GetComponent<CameraFollowing>().ChangeTarget(Hero);
        Destroy(Plr.gameObject);
    }

    public void CameraOfDefeatedPlayerCollision(Transform PositionOfBadPlayer)
    {
        if(PlayerIsDefeated)
            {

            BdPlr.transform.position = PositionOfBadPlayer.position;
        }
        PlayerIsDefeated = false;
    }

    // ------------------------ Check point ------------------------------

    public void CheckPointSpot(float x, float y)
    {
        Ponto.position = new Vector2(x, y);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerDeath();
        }
    }

}
