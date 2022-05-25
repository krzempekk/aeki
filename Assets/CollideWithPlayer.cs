using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideWithPlayer : MonoBehaviour
{
    List<ResetPosition> resets;

    [SerializeField] List<GameObject> objectsToReset;

    void Start()
    {
        resets = objectsToReset.ConvertAll(new Converter<GameObject, ResetPosition>(GetResetPosition));
    }

    public static ResetPosition GetResetPosition(GameObject gameObject)
    {
        return gameObject.GetComponent<ResetPosition>();
    }

    private void OnTriggerEnter(Collider other)
    {

        //Debug.Log(other.tag);
        if(other.CompareTag("Player"))
        {

            foreach (var reset in resets) 
                reset.DoReset();

            Debug.Log("collided with player");
        }
    }   
}
