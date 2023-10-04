using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    private float bellow;
    private Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {
        bellow = -2f;
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (body.transform.position.y < bellow)
        {
            body.transform.position = new Vector3(0f, 1f, 3.006877f);
        }
    }
}
