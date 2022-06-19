using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallOnPlayerCollision : MonoBehaviour
{
    public float fallDelay = 0.001f;
    public float fallTime = 3f;
    private Rigidbody rigidbody;
    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        this.rigidbody = GetComponent<Rigidbody>();
        this.initialPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(this.rigidbody + " Collided with " + collision.rigidbody);
        StartCoroutine(WaitAndFall());
        StartCoroutine(WaitAndReturnToInitialPosition());

    }

    private IEnumerator WaitAndFall()
    {
        Debug.Log("Coroutine starts...");

        yield return new WaitForSeconds(fallDelay);

        Debug.Log("Coroutine ended waiting");

        rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        rigidbody.useGravity = true;
    }

    private IEnumerator WaitAndReturnToInitialPosition()
    {
        Debug.Log(initialPosition);
        yield return new WaitForSeconds(fallTime);
        rigidbody.useGravity = false;
        transform.position = initialPosition;
        rigidbody.constraints = RigidbodyConstraints.FreezeAll;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
