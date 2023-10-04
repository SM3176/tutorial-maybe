using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FirstPersonCamera : MonoBehaviour
{
    public GameObject cam;
    private float xInput, yInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        xInput = Input.GetAxis("Mouse X");
        yInput = -Input.GetAxis("Mouse Y");

        transform.Rotate(transform.up, xInput);

        cam.transform.Rotate(new Vector3(yInput, 0, 0));
        
    }
}
