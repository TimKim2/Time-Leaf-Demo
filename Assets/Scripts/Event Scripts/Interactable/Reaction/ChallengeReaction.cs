using UnityEngine;

public class ChallengeReaction : DelayedReaction
{
    public int chalNum;

    protected override void ImmediateReaction()
    {
        FSLocator.challengeMgr.challist[chalNum] = true;
    }
}
