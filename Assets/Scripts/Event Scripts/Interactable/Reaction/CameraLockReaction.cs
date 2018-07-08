using UnityEngine;

public class CameraLockReaction : DelayedReaction
{
    public GameObject minimum;
    public GameObject maximum;
    protected override void ImmediateReaction()
    {
        FSLocator.controlManager.m_CameraFollow.LockCamera();
        FSLocator.controlManager.m_CameraFollow.SetRestrictedArea(maximum.transform.position.x, minimum.transform.position.x,
           maximum.transform.position.y, minimum.transform.position.y);
    }

	public override void Skip(){
		FSLocator.controlManager.m_CameraFollow.LockCamera();
		FSLocator.controlManager.m_CameraFollow.SetRestrictedArea(maximum.transform.position.x, minimum.transform.position.x,
			maximum.transform.position.y, minimum.transform.position.y);
	}
}