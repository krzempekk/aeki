using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour {
    public Vector2 pos;
    
    private bool activated = false;

    private void OnTriggerEnter(Collider other) {
        if(!activated && other.CompareTag("Player")) {
            GameObject.FindGameObjectWithTag("Maze").GetComponent<MazeController>().UncoverTiles(pos);
            activated = true;
        }
    }

    // Start is called before the first frame update
    void Start() {
        gameObject.transform.rotation.eulerAngles.Set(0, Random.Range(0, 4) * 90, 0);
        Texture texture = Resources.Load<Texture>("blood" + Random.Range(0, 4));
        GetComponent<Renderer>().material.SetTexture("_BaseMap", texture);
    }

    // Update is called once per frame
    void Update() {
        
    }
}
