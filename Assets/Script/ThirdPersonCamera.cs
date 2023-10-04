using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public GameObject target;
    public GameObject cam;

    private float xInput, yInput;

    // Update is called once per frame
    void Update()
    {
        //Make the camera always face its target
        cam.transform.LookAt(target.transform);

        //Follow the target around
        transform.position = target.transform.position;

        //Get mouse input, and rotate accordingly
        xInput = Input.GetAxis("Mouse X");
        yInput = -Input.GetAxis("Mouse Y");
        transform.Rotate(new Vector3(yInput, xInput, 0));
    }
}
