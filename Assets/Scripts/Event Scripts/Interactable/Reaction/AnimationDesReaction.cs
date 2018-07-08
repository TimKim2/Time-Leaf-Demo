using UnityEngine;
using System.Collections;

public class AnimationDesReaction : DelayedReaction
{
    public GameObject TargetObject;
    //public Vector3 moveDir;
    public DIR animDir;
    //public float distance;
    public float move_sp;
    public Transform destination;

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
        targetPosition = destination.position;
        TargetObject.GetComponent<PlayerAnimation>().SetDir(animDir);
        TargetObject.GetComponent<PlayerAnimation>().SetMove();
        CoroutineHandler.Start_Coroutine(AnimationPlay());

    }

	public override void Skip()
	{
		if (TargetObject.tag == "Player") {
			return;
		}

		targetPosition = destination.position;
		TargetObject.GetComponent<PlayerAnimation>().SetDir(animDir);
		TargetObject.transform.position = targetPosition;
	}

    IEnumerator AnimationPlay()
    {
        while (targetPosition != TargetObject.transform.position)
        {
            TargetObject.transform.position = Vector3.MoveTowards(TargetObject.transform.position, targetPosition, move_sp * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }
        //GameObject go = GameObject.Find("CoroutineHandler");
        //Destroy(go);
        TargetObject.GetComponent<PlayerAnimation>().SetIdle();
       // Debug.Log("Animation End");
        FSLocator.controlManager.m_Button.enabled = true;
        FSLocator.controlManager.m_Button.onClick.Invoke();
    }
}