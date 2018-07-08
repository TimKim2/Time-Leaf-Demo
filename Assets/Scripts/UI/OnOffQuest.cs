using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnOffQuest : MonoBehaviour
{
    public RectTransform qusetUI;

    Vector3 startPosition = new Vector3(-1295, 0, 0);
    Vector3 endPosition = new Vector3(-675, 0, 0);

    public Text txt;

    [HideInInspector]
    public bool isOn;

    OnOffUI onoffUI;
    Quest quest;

    private void Start()
    {
        onoffUI = GameObject.FindGameObjectWithTag("PanelUI").GetComponent<OnOffUI>();
        quest = GameObject.FindGameObjectWithTag("Quest").GetComponent<Quest>();
    }

    public void OnUI()
    {
        txt.text = quest.queststring;

        if (isOn)
            StartCoroutine(UIOff());
        else
        {
            StartCoroutine(UIOn());

            if(onoffUI.isOn)
            {
                onoffUI.StartCoroutine(onoffUI.UIOff());
                onoffUI.isOn = false;
            }
        }

        isOn = !isOn;
    }

    IEnumerator UIOn()
    {
        float timeOfTravel = 0.5f; //time after object reach a target place 
        float currentTime = 0; // actual floting time 
        float normalizedValue;

        while (currentTime <= timeOfTravel)
        {
            currentTime += Time.deltaTime;
            normalizedValue = currentTime / timeOfTravel; // we normalize our time 


            qusetUI.anchoredPosition = Vector3.Lerp(startPosition, endPosition, normalizedValue);

            yield return null;
        }
    }

    public IEnumerator UIOff()
    {
        float timeOfTravel = 0.5f; //time after object reach a target place 
        float currentTime = 0; // actual floting time 
        float normalizedValue;

        while (currentTime <= timeOfTravel)
        {
            currentTime += Time.deltaTime;
            normalizedValue = currentTime / timeOfTravel; // we normalize our time 

            qusetUI.anchoredPosition = Vector3.Lerp(endPosition, startPosition, normalizedValue);

            yield return null;
        }
    }
}