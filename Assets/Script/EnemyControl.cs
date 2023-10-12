using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    RaycastHit ray;
    bool hit;

    // Start is called before the first frame update
    void Start()
    {
        hit = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Origin = transform.position + transform.up * 3;
        Vector3 destination = transform.forward;
        float distance = 5;

        hit = Physics.Raycast(Origin, destination, out ray, distance);

        Debug.DrawRay(Origin, destination * distance, Color.red, 0.01f);

        if (hit)
        {
            if (ray.collider.gameObject.tag == "Player")
            {
                print("GOTCHA!");
            }

        }
    }
}
