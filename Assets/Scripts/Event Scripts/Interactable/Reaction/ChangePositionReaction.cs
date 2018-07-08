using UnityEngine;

public class ChangePositionReaction : DelayedReaction
{
    public GameObject target;
    public Transform pos;

    protected override void ImmediateReaction()
    {
        target.transform.position = pos.transform.position;
    }

	public void Skip()
	{
		if (target.tag == "Player") {
			return;
		}

		target.transform.position = pos.transform.position;
	}
}
