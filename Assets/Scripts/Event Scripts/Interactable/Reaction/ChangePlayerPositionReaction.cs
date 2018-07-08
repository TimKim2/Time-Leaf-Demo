using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerPositionReaction : DelayedReaction
{
    public Transform pos;

    protected override void ImmediateReaction()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = pos.transform.position;
    }
 }
