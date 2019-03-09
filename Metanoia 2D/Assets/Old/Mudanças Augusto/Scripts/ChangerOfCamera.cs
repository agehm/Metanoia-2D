using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangerOfCamera : MonoBehaviour {
    public bool Open;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Open)
        {
            collision.GetComponent<CameraFollowing>().ChangeCameraOpen(true);

            collision.GetComponent<CameraFollowing>().ChangeCameraClose(false);
        }
        else
        {
            collision.GetComponent<CameraFollowing>().ChangeCameraOpen(false);

            collision.GetComponent<CameraFollowing>().ChangeCameraClose(true);
        }
    }
}
