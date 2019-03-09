using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    private Transform robot, limitRight, limitLeft;

    private Vector3 _innerPosition;

    void Update()
    {
        //transform.position = new Vector3(robot.transform.position.x + 2, robot.transform.position.y + 1, transform.position.z);
        _innerPosition = new Vector3(robot.transform.position.x, robot.position.y + 1, transform.position.z);

        if(_innerPosition.x < limitRight.position.x)
        {
            _innerPosition.x = limitRight.position.x;
        }

        if (_innerPosition.x > limitLeft.position.x)
        {
            _innerPosition.x = limitLeft.position.x;
        }

        transform.position = _innerPosition;
    }
}
