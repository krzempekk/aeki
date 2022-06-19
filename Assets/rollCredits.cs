using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rollCredits : MonoBehaviour
{
    public GameObject credits;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            credits.SetActive(true);
        }
    }
}
