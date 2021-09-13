using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1_Movement : MonoBehaviour
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
        if (Input.GetKey(KeyCode.W)){
            transform.position = new Vector3(transform.position.x, transform.position.y + movementspeed, transform.position.z);
        }
        if (Input.GetKey(KeyCode.S)){
            transform.position = new Vector3(transform.position.x, transform.position.y - movementspeed, transform.position.z);
        }
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        
    }
}
