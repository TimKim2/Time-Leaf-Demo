using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour {
    public GameObject ui_Panel;
    public GameObject myPanel;
    public GameObject uiBackground;
    public GameObject ui_Quest;

    public GameObject joystick;
    public GameObject interactableBtn;

    public void OnUIPanel()
    {
        ui_Panel.SetActive(true);
        ui_Quest.SetActive(true);
        myPanel.SetActive(false);
        uiBackground.SetActive(false);
    }

    void OnEnable()
    {
        joystick.SetActive(false);
        interactableBtn.SetActive(false);
    }

    void OnDisable()
    {
        joystick.SetActive(true);
        interactableBtn.SetActive(true);
    }
}
