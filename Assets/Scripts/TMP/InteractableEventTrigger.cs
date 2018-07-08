using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 임시 테스트 스크립트
public class InteractableEventTrigger : MonoBehaviour {

    private Interactable currentInteractable;

    [HideInInspector]
    public InteractableButtonController interactableButton;

    public bool IsClick;

    private void Awake()
    {
        currentInteractable = this.GetComponent<Interactable>();
        interactableButton = GameObject.FindGameObjectWithTag("InteractableButton").GetComponent<InteractableButtonController>();
    }

	

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (IsClick)
            return;

        if (coll.CompareTag("Player"))
        {
            currentInteractable.Interact();
        }
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.CompareTag("PlayerTrigger") && interactableButton.isPressed == true)
        {
            currentInteractable.Interact();
            interactableButton.isPressed = false;
        }
    }
}
