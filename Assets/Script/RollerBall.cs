using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
using TMPro;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed;
    private float xInput, zInput;
    public float jumpF;
    public TMP_Text uiHeader;
   // private GameObject mainCamera;

    private void Start()
    {
        //mainCamera = (GameObject)GameObject.FindWithTag("MainCamera");
        
    }


    void Update()
    {
        xInput = UnityEngine.Input.GetAxis("Horizontal");
        zInput = UnityEngine.Input.GetAxis("Vertical");
        
        if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
        {

            //transform.position += new Vector3(0, jumpF * Time.deltaTime, 0);
            transform.Translate(new Vector3(0, jumpF, 0) * Time.deltaTime * speed);
        }

        transform.Translate(new Vector3(xInput, 0, zInput) * Time.deltaTime * speed);
        uiHeader.text = "x = " + xInput + ", z = " + zInput;
        // mainCamera.transform.position = new Vector3(transform.position.x, 2.86f, transform.position.z);
        //transform.position -= new Vector3(0, 3f * Time.deltaTime, 0);

    }


}
