using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootInDirection : MonoBehaviour
{

    public double minDistance = 1;
    public Vector3 shootDirection = new Vector3(20f, 0, 0);
    public float speed = 1f;
    public GameObject walls;
    private bool alreadyActivated;
    private bool shouldMove;
    private Rigidbody rigidbody;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.FindGameObjectWithTag("Player").transform;
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
            rigidbody.MovePosition(transform.position + shootDirection * speed * Time.fixedDeltaTime);
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
