using UnityEngine;

public class CameraShakeStartReaction : DelayedReaction
{
    public bool shakePosition;
    public bool shakeRotation;
    public float shakeIntensity;
    public float shakeDecay;
    protected override void ImmediateReaction()
    {
        FSLocator.controlManager.m_CameraShaking.Init(shakePosition, shakeRotation, shakeIntensity, shakeDecay);
        FSLocator.controlManager.m_CameraShaking.DoShake();
    }
}
