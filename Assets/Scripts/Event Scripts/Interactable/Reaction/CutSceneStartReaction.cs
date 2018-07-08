using UnityEngine;
using UnityEngine.UI;
public class CutSceneStartReaction : DelayedReaction
{
    protected override void ImmediateReaction()
    {
        //FSLocator.controlManager.m_Button.enabled = false;
        FSLocator.controlManager.m_CutSceneFrame.SetActive(true);
        FSLocator.controlManager.m_CutSceneFrame.GetComponent<CanvasGroup>().alpha = 1;
    }
}