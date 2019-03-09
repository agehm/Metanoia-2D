using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotControl : MonoBehaviour
{
    [SerializeField]
    private float speed, lifeTime;

    private Vector2 moveDirection;

    private void Start()
    {
        //moveDirection = Vector2.right;
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }

    public void SetDirection(Vector2 Direction)
    {
        moveDirection = Direction;
    }
}
