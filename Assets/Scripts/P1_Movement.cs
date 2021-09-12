using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1_Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        public float movementspeed = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)){
            transform.position = new Vector3(transform.position.x, transform.position.y - movementspeed, transform.position.z);
        }
        if (Input.GetKey(KeyCode.S)){
            transform.position = new Vector3(transform.position.x, transform.position.y + movementspeed, transform.position.z);
        }
    }
}
