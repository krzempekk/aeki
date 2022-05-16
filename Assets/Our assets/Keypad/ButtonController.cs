using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour  {
    public UnityEvent ButtonClicked;
    Animator animator;
    public Vector3 target;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    private void Update() {
        Vector3 position = transform.localPosition;
        transform.localPosition = new Vector3(position.x, position.y, target.z);
    }

    void OnMouseDown() {
        ButtonClicked.Invoke();   
        animator.SetTrigger("Pressed");
    }
}
