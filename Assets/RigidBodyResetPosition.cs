using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyResetPosition : MonoBehaviour
{
    private Vector3 initialPosition;
    public float heightLimit = -18f;
    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        initialPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rigidbody.position.y < heightLimit)
        {
            rigidbody.position = initialPosition;
        }
    }
}
