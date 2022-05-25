using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{

    public Vector3 initialPosition;

    public virtual void DoReset()
    {
        Debug.Log("Reset position of " + transform);
        transform.position = initialPosition;
    }
}
