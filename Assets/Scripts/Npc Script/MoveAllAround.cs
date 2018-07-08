using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAllAround : MonoBehaviour {

	Vector3 moveDir;
	DIR animDir;
	public float distance;
	public float move_sp;

	Vector3 center;

	int eventCheck = 1;

	public float delayTime;

	int dir = 1;

	Vector3 targetPosition;

	float randomDistance;
	Vector3 randomVector;
	float randomX;
	float randomY;

	void Awake()
	{
		center = transform.position;
	}

	void Start()
	{
		AnimationInvoke ();
	}

	public void AnimationInvoke()
	{
		randomDistance = Random.Range (0.0f, distance);
		randomX = Random.Range (-1.0f, 1.0f);
		randomY = Random.Range (-1.0f, 1.0f);
		randomVector = new Vector3(randomX, randomY, 0.0f);
		randomVector.Normalize ();

		Debug.Log (randomX);
		Debug.Log (randomY);

		targetPosition = center + dir * randomVector * randomDistance;

		Vector3 axis = targetPosition - transform.position;

		float angle = Vector3.Angle(Vector3.right, axis);

		if (angle < 45)
		{
			animDir = DIR.RIGHT;
		}
		else if (angle > 45 && angle < 135)
		{
			if (axis.y > 0)
			{
				animDir = DIR.UP;
			}
			else if (axis.y < 0)
			{
				animDir = DIR.DOWN;
			}
		}
		else
		{
			animDir = DIR.LEFT;
		}




		gameObject.GetComponent<PlayerAnimation>().SetDir(animDir);
		gameObject.GetComponent<PlayerAnimation>().SetMove();



		StartCoroutine (AnimationPlay ());

	}

	IEnumerator AnimationPlay()
	{
		while (targetPosition != gameObject.transform.position)
		{
			//Debug.Log ("go??");
			gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPosition, move_sp * Time.deltaTime * eventCheck);
			yield return new WaitForFixedUpdate();
		}

		gameObject.GetComponent<PlayerAnimation>().SetIdle();

		yield return new WaitForSeconds (1.0f);

		dir = dir * -1;

		AnimationInvoke ();

		//GameObject go = GameObject.Find("CoroutineHandler");
		//Destroy(go);

	}

	IEnumerator EventOffDelay()
	{
		yield return new WaitForSeconds (1.0f);
		OffEvent ();
	}


	public void OnEvent()
	{
		eventCheck = 0;
		gameObject.GetComponent<PlayerAnimation> ().SetIdle ();
	}

	public void OffEvent()
	{
		eventCheck = 1;
		gameObject.GetComponent<PlayerAnimation> ().SetMove ();
	}

	void OnCollisionEnter2D(Collision2D collider)
	{
		OnEvent ();
	}

	void OnCollisionExit2D(Collision2D collider)
	{
		StartCoroutine (EventOffDelay ());

	}
}
