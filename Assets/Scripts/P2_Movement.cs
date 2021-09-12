using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2_Movement : MonoBehaviour
{
    public float movementspeed;

    // Start is called before the first frame update
    void Start()
    {
        movementspeed = .05f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + movementspeed, transform.position.z);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - movementspeed, transform.position.z);
        }
    }
}
