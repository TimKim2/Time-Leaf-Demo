﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ReactionCollection : MonoBehaviour
{
    public Reaction[] reactions = new Reaction[0];

    private int startIndex = 0;
    [HideInInspector]
    public float delaytime;

    private void Start()
    {
        for (int i = 0; i < reactions.Length; i++)
        {
            DelayedReaction delayedReaction = reactions[i] as DelayedReaction;

            if (delayedReaction)
                delayedReaction.Init();
            else
                reactions[i].Init();
        }
    }


    public void React()
    {
        //React 하고 있을 때는 무조건 스크린 터치를 끈다.
        GameObject go = GameObject.Find("CoroutineHandler");
        Destroy(go);
        FSLocator.controlManager.m_Button.onClick.RemoveAllListeners();

        if (FSLocator.textDisplayer.isTyping)
        {
            FSLocator.textDisplayer.SkipTypingLetter();
            FSLocator.controlManager.m_Button.onClick.RemoveAllListeners();
            FSLocator.controlManager.m_Button.onClick.AddListener(delegate { this.React(); });
            return;
        }
        for (int i = startIndex; i < reactions.Length; i++)
        {
            //Debug.Log(i);
            DelayedReaction delayedReaction = reactions[i] as DelayedReaction;

            if (delayedReaction)
            {
                if (reactions[i].GetType().Name == "TextReaction")
                {
                    if (startIndex == reactions.Length - 1)
                        break;
                    else
                    {
                        startIndex = i + 1;
                        delayedReaction.React(this);
                        FSLocator.controlManager.m_Button.onClick.RemoveAllListeners();
                        FSLocator.controlManager.m_Button.onClick.AddListener(delegate { this.React(); });
                        return;
                    }
                }
                else if (reactions[i].GetType().Name == "DelayReaction")
                {
                    if (startIndex == reactions.Length - 1)
                        break;
                    else
                    {
                        startIndex = i + 1;
                        FSLocator.controlManager.m_Button.onClick.RemoveAllListeners();
                        FSLocator.controlManager.m_Button.onClick.AddListener(delegate { this.React(); });
                        delayedReaction.React(this);
                        return;
                    }
                }
                else if (reactions[i].GetType().Name == "AnimationReaction")
                {
                    if (startIndex == reactions.Length - 1)
                        break;
                    else
                    {
                        startIndex = i + 1;
                        FSLocator.controlManager.m_Button.onClick.RemoveAllListeners();
                        FSLocator.controlManager.m_Button.onClick.AddListener(delegate { this.React(); });
                        delayedReaction.React(this);
                        return;
                    }
                }

                else if (reactions[i].GetType().Name == "AnimationDesReaction")
                {
                    if (startIndex == reactions.Length - 1)
                        break;
                    else
                    {
                        startIndex = i + 1;
                        FSLocator.controlManager.m_Button.onClick.RemoveAllListeners();
                        FSLocator.controlManager.m_Button.onClick.AddListener(delegate { this.React(); });
                        delayedReaction.React(this);
                        return;
                    }
                }
                else if (reactions[i].GetType().Name == "EventCallbackReaction" || reactions[i].GetType().Name == "EventCallbackConditionReaction")
                {
                    startIndex = 0;
                   // Debug.Log("Event Callback");
                    delayedReaction.React(this);
                    return;
                }
                else if (reactions[i].GetType().Name == "SkipReaction")
                {
                    Skip();
                    FSLocator.controlManager.m_Button.onClick.RemoveAllListeners();
                    FSLocator.controlManager.m_Button.onClick.AddListener(delegate { this.React(); });
                    return;
                }
                else
                {
                  //  Debug.Log("Other Reaction");
                    delayedReaction.React(this);
                }
            }
            else
            {
                if (reactions[i].GetType().Name == "TextConditionReaction")
                {
                    reactions[i].React(this);
                    if (FSLocator.controlManager.reactPreCondition)
                    {
                        if (startIndex == reactions.Length - 1)
                        {
                            FSLocator.controlManager.reactPreCondition = false;
                            break;
                        }
                        else
                        {
                            startIndex = i + 1;
                            FSLocator.controlManager.reactPreCondition = false;
                            FSLocator.controlManager.m_Button.onClick.RemoveAllListeners();
                            FSLocator.controlManager.m_Button.onClick.AddListener(delegate { this.React(); });
                            return;
                        }
                    }

                }
            }
        }
        startIndex = 0;

    }

	public void Skip()
	{
		for (int i = startIndex; i < reactions.Length; i++)
		{
			reactions [i].Skip ();
        }

	}

	public void MoveAround()
	{
		reactions[0].React(this);
	}
  
}
