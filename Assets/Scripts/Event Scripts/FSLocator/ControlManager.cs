using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.PostProcessing;

public class ControlManager : MonoBehaviour
{
    [HideInInspector]
    public Button m_Button;
    [HideInInspector]
    public PlayerMoveByJoystick m_Player;
    [HideInInspector]
    public JoyStickBall m_Joystick;
    [HideInInspector]
    public GameObject m_InteractableButton;
    [HideInInspector]
    public GameObject m_CutSceneFrame;
    [HideInInspector]
    public CameraFollow m_CameraFollow;
    [HideInInspector]
    public GameObject m_UIObj;
    [HideInInspector]
    public CameraShaking m_CameraShaking;
	[HideInInspector]
	public GameObject m_JoyStickPanel;
    [HideInInspector]
    public PostProcessingBehaviour m_PostProcessingBehaviour;

    [HideInInspector]
    public bool reactPreCondition { get; set; }

    [HideInInspector]
    public bool EventIsPlaying { get; set; }

    void Awake()
    {
        m_Button = GameObject.FindGameObjectWithTag("ScreenTouch").GetComponent<Button>();
        m_Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMoveByJoystick>();
        m_Joystick = GameObject.FindGameObjectWithTag("JoyStick").GetComponent<JoyStickBall>();
        m_InteractableButton = GameObject.FindGameObjectWithTag("InteractableButton");
        m_CutSceneFrame = GameObject.FindGameObjectWithTag("CutSceneFrame");
        m_CameraFollow = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
        m_UIObj = GameObject.FindGameObjectWithTag("UISystem");
        m_CameraShaking = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShaking>();
		m_JoyStickPanel = GameObject.FindGameObjectWithTag ("JoyStickPannel");		 
        m_CutSceneFrame.SetActive(false);
        m_PostProcessingBehaviour = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PostProcessingBehaviour>();
        reactPreCondition = false;
        EventIsPlaying = false;
    }

}
