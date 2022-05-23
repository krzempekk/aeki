using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player; //drag and stop player object in the inspector
    public float minDistance;
    public float hitDistance;
    public float speed;
    RaycastHit hit;

    public void Update()
    {

        Vector3 playerPosition2D = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);

        transform.LookAt(playerPosition2D);

        Vector3 rayPosition = transform.position + new Vector3(0, 2, 0);
        Vector3 playerHeadPosition = player.position + new Vector3(0, 1.5f, 0);

        Vector3 forward = (playerHeadPosition - rayPosition) * 100;
        Debug.DrawRay(rayPosition, forward, Color.green);

        float distance = Vector3.Distance(rayPosition, playerHeadPosition);
        if (distance < minDistance && distance > hitDistance)
        {
            if (Physics.Raycast(rayPosition, (playerHeadPosition - rayPosition), out hit, Mathf.Infinity))
            {
                if (hit.transform.name == "PlayerCapsule")
                {
                    //Debug.Log("enemy should go");

                    transform.position = Vector3.MoveTowards(transform.position, playerPosition2D, speed);
                }
            }
        }


    }
}
