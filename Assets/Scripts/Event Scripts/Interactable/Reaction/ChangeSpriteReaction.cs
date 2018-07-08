using UnityEngine;

public class ChangeSpriteReaction : DelayedReaction
{
    public SpriteRenderer target;
    public Sprite image;
    protected override void ImmediateReaction()
    {
        target.sprite = image;
    }
}
