using UnityEngine;

public class GameObjectDestroyReaction : DelayedReaction
{
    public GameObject gameObject;

    protected override void ImmediateReaction()
    {
        Destroy(gameObject);
    }
}