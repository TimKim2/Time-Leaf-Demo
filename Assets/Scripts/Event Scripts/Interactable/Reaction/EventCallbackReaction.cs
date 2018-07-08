using UnityEngine;

public class EventCallbackReaction : DelayedReaction
{
    public ReactionCollection newReactionCollection;
    protected override void ImmediateReaction()
    {
        FSLocator.controlManager.m_Button.onClick.RemoveAllListeners();
        FSLocator.controlManager.m_Button.onClick.AddListener(delegate { newReactionCollection.React(); });
        FSLocator.controlManager.m_Button.onClick.Invoke();
    }

	public override void Skip()
	{
		newReactionCollection.Skip ();
	}
}