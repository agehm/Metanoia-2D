using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderJointControl : MonoBehaviour
{

    [SerializeField]
    private SliderJoint2D sliderJoint;
    [SerializeField]
    private JointMotor2D jointMotor;

    void Start()
    {
        jointMotor = sliderJoint.motor;
    }

    void Update()
    {
        if(sliderJoint.limitState == JointLimitState2D.LowerLimit)
        {
            jointMotor.motorSpeed = 1;
            sliderJoint.motor = jointMotor;
        }

        if (sliderJoint.limitState == JointLimitState2D.UpperLimit)
        {
            jointMotor.motorSpeed = -1;
            sliderJoint.motor = jointMotor;
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        collision.transform.parent = transform;
    //        collision.GetComponent<Rigidbody2D>().isKinematic = true;
    //    }
    //}
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        collision.transform.parent = null;
    //        collision.GetComponent<Rigidbody2D>().isKinematic = false;
    //    }
    //}
}
