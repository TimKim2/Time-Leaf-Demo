﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneTextReaction : DelayedReaction
{
    public string Text;
    public float dissolveTime;
    public float maintainTime;
    public bool showTextOnebyOne = false;
    public float timeBetUpdateLetters;

    protected override void ImmediateReaction()
    {
        if (!showTextOnebyOne)
            FSLocator.cutSceneTextDisplayer.DrawText(Text, dissolveTime, maintainTime);
        else
            FSLocator.cutSceneTextDisplayer.Say(Text, dissolveTime, maintainTime, timeBetUpdateLetters);
    }
}
