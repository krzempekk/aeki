using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectAndTransition : MonoBehaviour
{

    public GameObject collectPrompt;
    public KeyCode key;
    
    private bool isPlayerInside = false;

    // Start is called before the first frame update
    void Start()
    {
        collectPrompt.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key) && isPlayerInside)
        {
            PhaseSceneLoader.LoadPhase2();
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            collectPrompt.gameObject.SetActive(true);
            isPlayerInside = true;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.tag == "Player")
        {
            collectPrompt.gameObject.SetActive(false);
            isPlayerInside = false;
        }
    }
}
