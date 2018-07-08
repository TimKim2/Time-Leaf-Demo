using UnityEngine;

public class CameraUnlockReaction : DelayedReaction
{
    protected override void ImmediateReaction()
    {
        FSLocator.controlManager.m_CameraFollow.UnlockCamera();
    }
}