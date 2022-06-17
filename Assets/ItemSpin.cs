using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpin : MonoBehaviour
{
    private float time = 0f;

    private const float MAX_ROTATION_X = 3f;
    private const float MAX_ROTATION_Y = 2f;
    private const float MAX_ROTATION_Z = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        gameObject.transform.Rotate(new Vector3(
            MAX_ROTATION_X * Mathf.Sin(time),
            MAX_ROTATION_Y * Mathf.Sin(2.5f * time),
            MAX_ROTATION_Z * Mathf.Sin(3.5f * time)));
    }
}
