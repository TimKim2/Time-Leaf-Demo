using UnityEngine;
using System.Collections;

public class AnimationReaction : DelayedReaction
{
    public GameObject TargetObject;
    public Vector3 moveDir;
    public DIR animDir;
    public float distance;
    public float move_sp;

    //private TextManager textManager;

    Vector3 targetPosition;

    protected override void SpecificInit()
    {
        // textManager = FindObjectOfType<TextManager> ();
    }


    protected override void ImmediateReaction()
    {
        //Debug.Log("Animation Start");
        FSLocator.controlManager.m_Button.enabled = false;
        targetPosition = TargetObject.transform.position + moveDir * distance;
        TargetObject.GetComponent<PlayerAnimation>().SetDir(animDir);
        TargetObject.GetComponent<PlayerAnimation>().SetMove();
		//Debug.Log ("A");
        CoroutineHandler.Start_Coroutine(AnimationPlay());
		//Debug.Log ("B");
    }

	public void Skip()
	{
		if (TargetObject.tag == "Player") {
			return;
		}

		targetPosition = TargetObject.transform.position + moveDir * distance;
		TargetObject.GetComponent<PlayerAnimation>().SetDir(animDir);
		TargetObject.transform.position = targetPosition;
	}

    IEnumerator AnimationPlay()
    {
        while (targetPosition != TargetObject.transform.position)
        {
			//Debug.Log ("This");
            TargetObject.transform.position = Vector3.MoveTowards(TargetObject.transform.position, targetPosition, move_sp * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }
        //GameObject go = GameObject.Find("CoroutineHandler");
        //Destroy(go);
        TargetObject.GetComponent<PlayerAnimation>().SetIdle();
        //Debug.Log("Animation End");
        FSLocator.controlManager.m_Button.enabled = true;
        FSLocator.controlManager.m_Button.onClick.Invoke();
    }
}