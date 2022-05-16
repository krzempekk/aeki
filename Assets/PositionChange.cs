using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionChange : MonoBehaviour
{

    [SerializeField] Vector3[] myAngles;
    [SerializeField] int rotationFrame = 60;
    int len;
    int idx = 0;
    int frame = 0;


    // Start is called before the first frame update
    void Start()
    {
        len = myAngles.Length;
    }

    // Update is called once per frame
    void Update()
    {
        idx = (idx + 1) % len;
        if (frame == rotationFrame - 1) {
            transform.rotation = Quaternion.Euler(myAngles[idx]);
        }
        frame = (frame + 1) % rotationFrame;
    }
}
