using UnityEngine;

public class CameraFollowReaction : DelayedReaction
{
    public GameObject cameraTarget;
    public float cameraMovingSpeed;
    public bool accel;

    protected override void ImmediateReaction()
    {
        FSLocator.controlManager.m_CameraFollow.FollowTargetOBJ = cameraTarget;
        FSLocator.controlManager.m_CameraFollow.FollowSpeed = cameraMovingSpeed;

        if (accel)
            FSLocator.controlManager.m_CameraFollow.isAccel = true;
        else
            FSLocator.controlManager.m_CameraFollow.isAccel = false;       
    }
}