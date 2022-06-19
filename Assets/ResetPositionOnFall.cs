using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPositionOnFall : MonoBehaviour
{

    public Vector3 initialPosition;
    public bool useCurrentPosition;
    public float heightLimit = -15f;
    // Start is called before the first frame update
    void Start()
    {
       if (useCurrentPosition)
       {
           initialPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
       }
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= heightLimit)
        {
            Debug.Log("Resetting " + this +" position...");
            transform.position = initialPosition;
        }
    }
}
