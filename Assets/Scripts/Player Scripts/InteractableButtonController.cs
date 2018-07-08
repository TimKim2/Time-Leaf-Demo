using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InteractableButtonController : MonoBehaviour {

    public Button InteractableButton;
    public CanvasGroup InteractableButtonCanvasGroup;

    [HideInInspector]
    public bool isPressed = false;

    public void InteractableButtonOn()
    {
        InteractableButtonCanvasGroup.alpha = 1.0f;
        InteractableButton.enabled = true;
    }

    public void InteractableButtonOff()
    {
        InteractableButtonCanvasGroup.alpha = 0.0f;
        InteractableButton.enabled = false;
    }

    public void Click()
    {
        StartCoroutine(PressCorutine());
    }

    IEnumerator PressCorutine()
    {
        isPressed = true;

        yield return new WaitForSeconds(0.05f);

        isPressed = false;
    }
}
