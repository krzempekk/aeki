using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeypadController : MonoBehaviour {
    public string password = "2137";
    private string userInput = "";

    public AudioClip clickSound;
    public AudioClip grantedSound;
    public AudioClip deniedSound;
    AudioSource audioSource;

    public UnityEvent OnAccessGranted;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    public void ButtonClicked(string number) {
        audioSource.PlayOneShot(clickSound);
        userInput += number;

        if(userInput.Length < 4) {
            return;
        }

        if(userInput == password) {
            audioSource.PlayOneShot(grantedSound);
            OnAccessGranted.Invoke();
        } else {
            audioSource.PlayOneShot(deniedSound);
        }

        userInput = "";
    }
}
