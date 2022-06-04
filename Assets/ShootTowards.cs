using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTowards : MonoBehaviour
{

    public Transform player;

    public double minDistance = 1;
    public float thrust = 20f;
    public float speed = 1f;
    public GameObject walls;
    private bool alreadyActivated;
    private bool shouldMove;
    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        this.alreadyActivated = false;
        this.rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject == walls)
        {
            Debug.Log("Collided with " + collision.gameObject);
            shouldMove = false;
        }
    }

    private void FixedUpdate()
    {
        if (shouldMove)
        {
            rigidbody.MovePosition(transform.position + new Vector3(thrust, 0, 0) * speed * Time.fixedDeltaTime);
          //  speed = speed / 2f;
        }

    }

    // Update is called once per frame
    void Update()
    {
       
        if(!alreadyActivated && Vector3.Distance(player.transform.position, transform.position) < minDistance)
        {
            Debug.Log("Should apply force to " + name);
            alreadyActivated = true;
            shouldMove = true;
        }
    }
}
