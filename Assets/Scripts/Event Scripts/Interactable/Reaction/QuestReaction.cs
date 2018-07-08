using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestReaction : DelayedReaction
{
    public string quest;

    protected override void ImmediateReaction()
    {
        FSLocator.questMgr.queststring = quest;
    }
}
