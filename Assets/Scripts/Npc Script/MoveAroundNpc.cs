using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAroundNpc : MonoBehaviour {

	public Vector3 moveDir;
	public DIR animDir;
	public float distance;
	public float move_sp;

	int eventCheck = 1;

	public float delayTime;

	int dir = 1;

	Vector3 targetPosition;

	void Start()
	{
		AnimationInvoke ();
	}

	public void AnimationInvoke()
	{
		Debug.Log ("Is Move?");
		targetPosition = gameObject.transform.position + dir * moveDir * distance;

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

		if (animDir == DIR.UP) {
			animDir = DIR.DOWN;
		} else if (animDir == DIR.DOWN) {
			animDir = DIR.UP;
		} else if (animDir == DIR.LEFT) {
			animDir = DIR.RIGHT;
		} else if (animDir == DIR.RIGHT) {
			animDir = DIR.LEFT;
		}
			
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
		Debug.Log ("why not");
		OnEvent ();
	}

	void OnCollisionExit2D(Collision2D collider)
	{
		Debug.Log ("why not");
		StartCoroutine (EventOffDelay ());

	}


}
