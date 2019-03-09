using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadPlayer : MonoBehaviour {
    [SerializeField]
    private GameObject CapeGoingAway;

    [SerializeField]
    private GameObject CapeComingBack;

    [SerializeField]
    private GameObject Hero;

    // Use this for initialization
    void Start () {
        GameObject Cap = Instantiate(CapeGoingAway) as GameObject;
        Cap.transform.position = new Vector2(0, 0);
        Cap.transform.parent = gameObject.transform;
    }
	
    public void BadPlayerDefeated()
    {
        float x = transform.position.x;
        float y = transform.position.y;

        GameObject cgb = Instantiate(CapeComingBack) as GameObject;
        cgb.transform.position = new Vector2(0, 0.76f);
        cgb.transform.parent = gameObject.transform;



        // Destroy(gameObject.transform.parent.gameObject);
        //SceneManager.LoadScene("GameOver");
    }

}
