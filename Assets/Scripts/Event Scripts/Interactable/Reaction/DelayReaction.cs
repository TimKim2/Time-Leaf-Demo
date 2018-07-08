using UnityEngine;
using System.Collections;


public class DelayReaction : DelayedReaction
{
    public float delayTime;

    protected override void ImmediateReaction()
    {
       // Debug.Log("Delay Start");
        FSLocator.controlManager.m_Button.enabled = false;
        CoroutineHandler.Start_Coroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(delayTime);
        //GameObject go = GameObject.Find("CoroutineHandler");
        //Destroy(go);
        //Debug.Log("Delay End");
        FSLocator.controlManager.m_Button.enabled = true;
        FSLocator.controlManager.m_Button.onClick.Invoke();
    }
}