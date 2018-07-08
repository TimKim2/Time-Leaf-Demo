using UnityEngine;

public class NPCInteractDirectionReaction : DelayedReaction
{
    public GameObject NPC;
    public GameObject Player;
    protected override void ImmediateReaction()
    {
        NPC.GetComponent<PlayerAnimation>().SetInteractableDirection(Player, NPC);
        NPC.GetComponent<PlayerAnimation>().SetMove();
        NPC.GetComponent<PlayerAnimation>().SetIdle();
    }
}