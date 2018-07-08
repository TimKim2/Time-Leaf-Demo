using UnityEngine;
using System.Collections;

public class MoveAroundReaction : DelayedReaction
{
	public GameObject TargetObject;
	public Vector3 moveDir;
	public DIR animDir;
	public float distance;
	public float move_sp;

	int dir = 1;

	Vector3 targetPosition;

	protected override void SpecificInit()
	{
	}


	protected override void ImmediateReaction()
	{
		Debug.Log ("Is Move?");
		targetPosition = TargetObject.transform.position + dir * moveDir * distance;
		dir = dir * -1;
		TargetObject.GetComponent<PlayerAnimation>().SetDir(animDir);
		TargetObject.GetComponent<PlayerAnimation>().SetMove();
		CoroutineHandler.Start_Coroutine(AnimationPlay());

	}

	public void Invoke()
	{
		ImmediateReaction ();
	}
		
	IEnumerator AnimationPlay()
	{
		while (targetPosition != TargetObject.transform.position)
		{
			Debug.Log ("go??");
			TargetObject.transform.position = Vector3.MoveTowards(TargetObject.transform.position, targetPosition, move_sp * Time.deltaTime);
			yield return new WaitForFixedUpdate();
		}
		Debug.Log ("out??");
		TargetObject.GetComponent<PlayerAnimation>().SetIdle();

		Debug.Log ("Why??");

		Invoke ();

		GameObject go = GameObject.Find("CoroutineHandler");
		Destroy(go);


	}
}