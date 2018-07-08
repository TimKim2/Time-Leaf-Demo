using UnityEngine;

public class EmoticonReaction : DelayedReaction
{
    public GameObject target;
    public Sprite emoticonSprite;
    public float dissolveTime;
    public float maintainTime;
    protected override void ImmediateReaction()
    {
        target.GetComponent<EmoticonDisplayer>().DrawEmoticon(target, emoticonSprite, dissolveTime, maintainTime);
    }
}
