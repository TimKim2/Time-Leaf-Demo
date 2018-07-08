using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAnimationWithSound : MonoBehaviour
{
	public AudioClip audioClip;
	public AudioSource audioSource;

	public DIR currentAnimationDir = DIR.DOWN;
	public STATE currentState = STATE.STATE_IDLE;
	public Animator anim;
	public GameObject trigger;
	Dictionary<STATE, Action> StateAnimation = new Dictionary<STATE, Action>();


	// Use this for initialization
	void Awake()
	{
		StateAnimation.Add(STATE.STATE_IDLE, State_Idle);
		StateAnimation.Add(STATE.STATE_MOVE, State_Move);
	}

	// Update is called once per frame
	void Update()
	{
		StateAnimation[currentState]();
	}

	public void SetMove()
	{
		currentState = STATE.STATE_MOVE;
	}

	public void SetIdle()
	{
		currentState = STATE.STATE_IDLE;
	}

	DIR GetDir()
	{
		return currentAnimationDir;
	}

	public void SetRight()
	{
		currentAnimationDir = DIR.RIGHT;
		trigger.transform.localPosition = new Vector3(0.3f, 0, 0);
	}

	public void SetLeft()
	{
		currentAnimationDir = DIR.LEFT;
		trigger.transform.localPosition = new Vector3(-0.3f, 0, 0);
	}

	public void SetDown()
	{
		currentAnimationDir = DIR.DOWN;
		trigger.transform.localPosition = new Vector3(0, -0.4f, 0);
	}

	public void SetUp()
	{
		currentAnimationDir = DIR.UP;
		trigger.transform.localPosition = new Vector3(0, 0.4f, 0);
	}

	public void SetDir(DIR dir)
	{
		currentAnimationDir = dir;
	}

	private void State_Idle()
	{
		//Debug.Log("IDLE");
		switch (currentAnimationDir)
		{
		case DIR.UP:
			{
				anim.Play("Up_Idle");
				break;
			}
		case DIR.DOWN:
			{
				anim.Play("Down_Idle");
				break;
			}
		case DIR.LEFT:
			{
				anim.Play("Left_Idle");
				break;
			}
		case DIR.RIGHT:
			{
				anim.Play("Right_Idle");
				break;
			}

		}
	}

	public void State_Move()
	{
		//Debug.Log("MOVE");

		audioSource.clip = audioClip;
		audioSource.volume = 1.0f;
		audioSource.PlayDelayed (0);

		switch (currentAnimationDir)
		{
		case DIR.UP:
			{
				anim.Play("Up");
				break;
			}
		case DIR.DOWN:
			{
				anim.Play("Down");
				break;
			}
		case DIR.LEFT:
			{
				anim.Play("Left");
				break;
			}
		case DIR.RIGHT:
			{
				anim.Play("Right");
				break;
			}
		}
	}

	public void SetInteractableDirection(GameObject Player, GameObject NPC)
	{
		if (NPC.transform.position.x < Player.transform.position.x)
		{
			if (NPC.transform.position.y < Player.transform.position.y)
			{
				//1사분면
				if (Player.transform.position.x - NPC.transform.position.x < Player.transform.position.y - NPC.transform.position.y)
				{
					//위
					currentAnimationDir = DIR.UP;
				}
				else
				{
					//오른쪽

					currentAnimationDir = DIR.RIGHT;
				}
			}
			else
			{
				//4사분면
				if (-Player.transform.position.x + NPC.transform.position.x < Player.transform.position.y - NPC.transform.position.y)
				{
					//오른쪽
					currentAnimationDir = DIR.RIGHT;
				}
				else
				{
					//아래
					currentAnimationDir = DIR.DOWN;
				}
			}
		}
		else
		{
			if (NPC.transform.position.y < Player.transform.position.y)
			{
				//2사분면
				if (-Player.transform.position.x + NPC.transform.position.x < Player.transform.position.y - NPC.transform.position.y)
				{
					//위
					currentAnimationDir = DIR.UP;
				}
				else
				{
					//왼쪽
					currentAnimationDir = DIR.LEFT;
				}
			}
			else
			{
				//3사분면
				if (Player.transform.position.x - NPC.transform.position.x < Player.transform.position.y - NPC.transform.position.y)
				{
					//왼쪽
					currentAnimationDir = DIR.LEFT;
				}
				else
				{
					//아래
					currentAnimationDir = DIR.DOWN;
				}
			}
		}
	}
}
