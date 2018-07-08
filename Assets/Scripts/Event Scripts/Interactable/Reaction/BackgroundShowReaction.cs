using UnityEngine;

public class BackgroundShowReaction : DelayedReaction
{
    public Sprite background;
    protected override void ImmediateReaction()
    {
        FSLocator.backgroundDisplayer.DrawBackground(background);
    }
}