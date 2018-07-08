using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStickPannel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
	
	public GameObject JoyStickFrame;

	// Use this for initialization
	void Start () {
		
		FSLocator.controlManager.m_Joystick.OffJoystick ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		JoyStickFrame.SetActive (true);

		JoyStickFrame.transform.position = Input.mousePosition;
		FSLocator.controlManager.m_Joystick.center = Input.mousePosition;
		FSLocator.controlManager.m_Joystick.MoveJoystick ();
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		FSLocator.controlManager.m_Joystick.HoldJoystick ();
		JoyStickFrame.SetActive (false);
	}
}
