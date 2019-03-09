using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onibus : MonoBehaviour
{
    public bool MoveLeftToRight;
    public float Speed;
    public float Damage = -20f;




    void Start()
    {
        Destroy(gameObject, 20);
    }

    void Update()
    {
        if (MoveLeftToRight)
            transform.Translate(Speed * Time.deltaTime, 0, 0);
        else
            transform.Translate(-Speed * Time.deltaTime, 0, 0);
    }
    


    
}
