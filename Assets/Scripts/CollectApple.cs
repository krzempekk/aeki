using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectApple : MonoBehaviour
{
    public float SpeedUpDuration = 10;

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            StartCoroutine(Collect(other));
        }
    }

    IEnumerator Collect(Collider player) {
        PlayerStats stats = player.GetComponent<PlayerStats>();
        stats.IncreaseSpeed();

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(SpeedUpDuration);

        stats.DecreaseSpeed();
        Destroy(gameObject);
    }
}
