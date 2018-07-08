using UnityEngine;

public class CameraShakeStopReaction : DelayedReaction
{
    protected override void ImmediateReaction()
    {
        FSLocator.controlManager.m_CameraShaking.Init(false, false, 0.0f, 0.0f);
        FSLocator.controlManager.m_CameraShaking.StopShake();
    }
}