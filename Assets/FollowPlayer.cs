using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player; //drag and stop player object in the inspector
    public float minDistance;
    public float speed;
    RaycastHit hit;
    Rigidbody rigidbody;

    public void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        rigidbody = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        transform.LookAt(player.transform);

        Vector3 rayPosition = transform.position + new Vector3(0, 2, 0);
        Vector3 playerHeadPosition = player.position + new Vector3(0, 1.5f, 0);

        Vector3 forward = (playerHeadPosition - rayPosition) * 100;
        Debug.DrawRay(rayPosition, forward, Color.green);

        if (Vector3.Distance(rayPosition, playerHeadPosition) < minDistance)
        {
            if (Physics.Raycast(rayPosition, (playerHeadPosition - rayPosition), out hit, Mathf.Infinity))
            {
                Debug.Log(hit.transform.name);
                if (hit.transform.name == "PlayerCapsule")
                {
                    Debug.Log("should go");


                    Vector3 playerPosition2D = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);

                    //rigidbody.MovePosition(playerPosition2D * Time.deltaTime * speed);

                    transform.position = Vector3.MoveTowards(transform.position, playerPosition2D, speed);
                }
            }
        }


    }
}
