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

        transform.Translate(new Vector3(xInput,0, zInput) * Time.deltaTime * speed);
        uiHeader.text = "x = " + xInput + ", z = " + zInput;
       // mainCamera.transform.position = new Vector3(transform.position.x, 2.86f, transform.position.z);
    }

}
