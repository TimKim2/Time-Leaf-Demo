using UnityEngine;

public class AnimChangeReaction : DelayedReaction
{
    public RuntimeAnimatorController anim;
    public GameObject go;

    protected override void ImmediateReaction()
    {
        go.GetComponent<Animator>().runtimeAnimatorController = anim;
    }
}
