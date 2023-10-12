using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateD : MonoBehaviour
{
    public float rotate = 4;
    private Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        body.transform.Rotate(0f, 0.3f, 0.0f, Space.Self);
    }
}
