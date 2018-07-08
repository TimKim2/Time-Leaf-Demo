using UnityEngine;

public class BackgroundHideReaction : DelayedReaction
{
    protected override void ImmediateReaction()
    {
        FSLocator.backgroundDisplayer.HideBackground();
    }
}