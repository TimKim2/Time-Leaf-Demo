using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugReaction : DelayedReaction
{
    public string debugLogDescription;
    protected override void ImmediateReaction()
    {
		Debug.Log(debugLogDescription);
    }
}
