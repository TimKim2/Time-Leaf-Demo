using UnityEngine;

public class GameObjectReaction : DelayedReaction
{
    public GameObject gameObject;
    public bool activeState;


    protected override void ImmediateReaction()
    {
        gameObject.SetActive(activeState);
    }

	public override void Skip(){
		gameObject.SetActive(activeState);
	}
}