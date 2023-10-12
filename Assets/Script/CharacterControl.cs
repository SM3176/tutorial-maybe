using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float jogS, runS, jumpP, turnS;
    private float speed;
    private Vector3 movement;
    private Rigidbody body;

    private float xInput, zInput;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        speed = jogS;
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

        if (Input.GetAxis("Run") > 0.1f)
        {
            speed = runS;
        }
        else
        {
            speed = jogS;
        }

        movement = new Vector3(xInput, 0, zInput) * 100 * speed * Time.deltaTime;

        if (movement.magnitude != 0)
        {
            Vector3 desiredForward = new Vector3(xInput, 0, zInput);
            if (desiredForward != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(desiredForward);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnS * Time.deltaTime);
            }
        }

        body.velocity = new Vector3(movement.x, body.velocity.y, movement.z);
    }

}
