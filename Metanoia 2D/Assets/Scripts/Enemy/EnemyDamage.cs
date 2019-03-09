using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MaterialControl))]
public class EnemyDamage : MonoBehaviour 
{
    [SerializeField]
    private int life = 125, damagePerHit = 25;

    private MaterialControl materialControl;

    void Start () 
	{
        materialControl = GetComponent<MaterialControl>();
    }
		
	void Update () 
	{
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);

            life -= 25;

            if (life > 0)
            {
                materialControl.UpColorSprite();
            }
            else
            {
                Destroy(gameObject.transform.parent.gameObject);
            }        
        }
    }
}
