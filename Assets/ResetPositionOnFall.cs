using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPositionOnFall : MonoBehaviour
{
    public GameObject resetPoint;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            other.transform.position = resetPoint.transform.position;
        }
    }
}
