using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public bool Active { get; set; }

    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform mouthTransform;
    [SerializeField]
    private float distanceToStart;
    [SerializeField]
    [Tooltip("InSeconds")]
    private float fireRate;
    [SerializeField]
    [Tooltip("Sprite looking for left")]
    private bool LookingForLeft;

    private float timeToNextShot;
    private bool canShot;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); //ToDo - Pegar pelo GameManager
    }

    private void Update()
    {
        if (Active)
        {
            VerifyPosition();

            if (canShot)
            {
                Shot();
            }
        }
    }

    private void VerifyPosition()
    {
        if (Vector2.Distance(player.transform.position, transform.position) < distanceToStart)
        {
            canShot = true;
        }
        else
        {
            canShot = false;
        }
    }

    private void Shot()
    {
        if (Time.time > timeToNextShot)
        {
            GameObject newBullet = Instantiate(bulletPrefab, mouthTransform.position, Quaternion.identity);
            newBullet.GetComponent<ShotControl>().SetDirection(GetDirection());
            timeToNextShot = Time.time + fireRate;
        }
    }

    private Vector2 GetDirection()
    {
        if (LookingForLeft)
        {
            if (ScaleIsNegative())
            {
                return Vector2.right;
            }

            return Vector2.left;
        }

        if (ScaleIsNegative())
        {
            return Vector2.left;
        }

        return Vector2.right;
    }

    private bool ScaleIsNegative()
    {
        if (transform.localScale.x < 0)
        {
            return true;
        }

        return false;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, distanceToStart);
    }
}
