using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerOfFire : MonoBehaviour
{
    public float currentTime;
    public float WaitTime = 2;
    public GameObject Fire;


    void Update()
    {
        currentTime += Time.deltaTime;
            if (currentTime >= WaitTime)
            {

                GameObject tempPrefab = Instantiate(Fire) as GameObject;
                tempPrefab.transform.position = new Vector2(transform.position.x, transform.position.y);
            currentTime = 0;
            }
            
        
    }
}
