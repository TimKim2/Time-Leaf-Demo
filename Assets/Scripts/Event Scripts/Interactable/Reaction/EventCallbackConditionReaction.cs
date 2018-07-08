using UnityEngine;


public class EventCallbackConditionReaction : DelayedReaction
{
    public ConditionCollection[] conditionCollections = new ConditionCollection[0];
    public ReactionCollection defaultReactionCollection;

    protected override void ImmediateReaction()
    {
        FSLocator.controlManager.m_Button.onClick.RemoveAllListeners();
        Interact();
    }

    public void Interact()
    {
        for (int i = 0; i < conditionCollections.Length; i++)
        {
            if (conditionCollections[i].Check())
            {
                conditionCollections[i].InvokeConditionReactionAndCallback();
                return;
            }
        }

        InvokeDefaultReactionAndCallback();
    }

    public void InvokeDefaultReactionAndCallback()
    {
        FSLocator.controlManager.m_Button.onClick.RemoveAllListeners();
        FSLocator.controlManager.m_Button.onClick.AddListener(delegate { defaultReactionCollection.React(); });
        FSLocator.controlManager.m_Button.onClick.Invoke();
    }

    public void Skip()
    {
        for (int i = 0; i < conditionCollections.Length; i++)
        {
            if (conditionCollections[i].CheckAndReact())
            {
                conditionCollections[i].SkipReaction();
                return;
            }
        }
        defaultReactionCollection.Skip();


    }
}