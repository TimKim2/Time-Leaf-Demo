using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTextReaction : DelayedReaction
{
    public string Text;
    public float dissolveTime;
    public float maintainTime;
    public bool showTextOnebyOne = false;
    public float timeBetUpdateLetters;
    protected override void ImmediateReaction()
    {
        if (!showTextOnebyOne)
            FSLocator.backgroundDisplayer.DrawBackgroundText(Text, dissolveTime, maintainTime);
        else
            FSLocator.backgroundDisplayer.Say(Text, dissolveTime, maintainTime, timeBetUpdateLetters);
    }
}
