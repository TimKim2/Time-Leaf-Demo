using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

enum JOYSTICKSTATE
{
    HOLD, MOVE,
};

public class JoyStickBall : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject actor;
    [HideInInspector]
    public PlayerAnimation m_PlayerAnimation;
    [HideInInspector]
    public PlayerMoveByJoystick m_PlayerJoystick;

    float radius = 30;
    public Vector3 center;

    Dictionary<JOYSTICKSTATE, Action> JoyStickStateUpdate = new Dictionary<JOYSTICKSTATE, Action>();
    JOYSTICKSTATE CurrentState = JOYSTICKSTATE.HOLD;

    public GameObject JoystickFrame;

    private void Awake()
    {
        m_PlayerAnimation = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAnimation>();
        m_PlayerJoystick = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMoveByJoystick>();

    }

    // Use this for initialization
    void Start()
    {
        center = transform.position;

        JoyStickStateUpdate.Add(JOYSTICKSTATE.HOLD, HoldCharacter);
        JoyStickStateUpdate.Add(JOYSTICKSTATE.MOVE, MoveCharacter);
    }

    // Update is called once per frame
    void Update()
    {
        JoyStickStateUpdate[CurrentState]();
    }

    void MoveCharacter()
    {
        Vector3 touchPos = Input.mousePosition;

		//if (touchPos.x > 300)
		//	return;
		
        Vector3 axis = (touchPos - center).normalized;

        SetAnimationDir(axis);

        m_PlayerJoystick.SetCurrentDir(axis);

        float distance = Vector3.Distance(touchPos, center);

        if (distance > radius)
        {
            transform.position = center + axis * radius;
        }
        else
        {
            transform.position = center + axis * distance;
        }
    }

    void HoldCharacter()
    {
    }

    public void HoldJoystick()
    {
        m_PlayerJoystick.SetCurrentDir(Vector3.zero);
        CurrentState = JOYSTICKSTATE.HOLD;
        m_PlayerAnimation.SetIdle();
        m_PlayerJoystick.SetCurrentDir(Vector3.zero);
        transform.position = center;
    }

    public void MoveJoystick()
    {
        CurrentState = JOYSTICKSTATE.MOVE;
        m_PlayerAnimation.SetMove();
    }

	public void ResetJoyStick()
	{
		
	}

    public void OnPointerDown(PointerEventData eventData)
    {
        MoveJoystick();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        HoldJoystick();
    }

    public void OffJoystick()
    {
        transform.position = center;
        HoldJoystick();
        //this.gameObject.SetActive(false);
        JoystickFrame.SetActive(false);
    }

    public void OnJoystick()
    {
        //this.gameObject.SetActive(true);
        JoystickFrame.SetActive(true);
    }

    void SetAnimationDir(Vector3 axis)
    {
        float angle = Vector3.Angle(Vector3.right, axis);

        if (angle < 45)
        {
            m_PlayerAnimation.SetRight();
        }
        else if (angle > 45 && angle < 135)
        {
            if (axis.y > 0)
            {
                m_PlayerAnimation.SetUp();
            }
            else if (axis.y < 0)
            {
                m_PlayerAnimation.SetDown();
            }
        }
        else
        {
            m_PlayerAnimation.SetLeft();
        }

    }
}



