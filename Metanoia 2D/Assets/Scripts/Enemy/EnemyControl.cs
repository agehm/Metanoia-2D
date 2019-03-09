using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour 
{
    [SerializeField]
     private float initialAnimationTime;	

	void Start () 
	{
        StartCoroutine(WaitForActiveFollow());
        StartCoroutine(WaitForActiveShot());
    }
		
    private IEnumerator WaitForActiveFollow()
    {
        yield return new WaitForSeconds(initialAnimationTime);

        EnemyFollow enemyFollow = GetComponent<EnemyFollow>();

        if(enemyFollow != null)
        {
            enemyFollow.Active = true;
        }
    }

    //0.5f - For not start shoting
    private IEnumerator WaitForActiveShot()
    {
        yield return new WaitForSeconds(initialAnimationTime + 0.5f);

        EnemyShot enemyShot = GetComponent<EnemyShot>();

        if (enemyShot != null)
        {
            enemyShot.Active = true;
        }
    }
}
