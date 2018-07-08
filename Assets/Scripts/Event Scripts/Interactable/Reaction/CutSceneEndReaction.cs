using UnityEngine;

public class CutSceneEndReaction : DelayedReaction
{
    protected override void ImmediateReaction()
    {
        //FSLocator.controlManager.m_Button.enabled = true;
        FSLocator.controlManager.m_CutSceneFrame.GetComponent<CanvasGroup>().alpha = 0;
        FSLocator.controlManager.m_CutSceneFrame.SetActive(false);
    }
}