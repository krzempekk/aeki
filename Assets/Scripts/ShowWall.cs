using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowWall : MonoBehaviour
{
    public GameObject wall;

    private void OnTriggerEnter(Collider other) {
        wall.SetActive(true);
    }
}
