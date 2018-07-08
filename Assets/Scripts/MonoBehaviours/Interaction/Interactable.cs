﻿using UnityEngine;
using UnityEngine.UI;
public class Interactable : MonoBehaviour
{
    public Transform interactionLocation;
    public ConditionCollection[] conditionCollections = new ConditionCollection[0];
    public ReactionCollection defaultReactionCollection;

    private bool isFirst = false;
	public bool isSkip;

	public void Start()
	{
		/*if (IsSkip) {
			for (int i = 0; i < conditionCollections.Length; i++)
			{
				conditionCollections [i].SkipReaction ();

			}
		}*/
	}

    // Event Trigger 딱 한번만 실행되는 시작함수 (조건에 맞으면, Start)
    public void Interact ()
    {
        for (int i = 0; i < conditionCollections.Length; i++)
        {			
			if (conditionCollections [i].CheckAndReact ()) {
				//isSkip = true;
				return;
			}
        }
        
        InvokeDefaultReaction();
    }

    public void InvokeDefaultReaction()
    {
        isFirst = false;
        if (!isFirst)
        {
            isFirst = true;
            if(!FSLocator.controlManager.EventIsPlaying)
                defaultReactionCollection.React();
           //isSkip = true;
        }
    }

}
	