using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnOffUI : MonoBehaviour
{
    public RectTransform qusetUI;

    public Sprite[] sprites;

    Image image;

    Vector3 startPosition = new Vector3(590, -43, 0);
    Vector3 endPosition = new Vector3(20, -43, 0);

    [HideInInspector]
    public bool isOn;

    OnOffQuest onoffQuest;

    void Start()
    {
        image = GetComponent<Image>();
        onoffQuest = GameObject.FindGameObjectWithTag("QuestUI").GetComponent<OnOffQuest>();
    }

    public void OnUI()
    {
        if (isOn)
        {
            StartCoroutine(UIOff());
        }

        else
        {
            StartCoroutine(UIOn());

            if(onoffQuest.isOn)
            {
                onoffQuest.StartCoroutine(onoffQuest.UIOff());
                onoffQuest.isOn = false;
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

        image.sprite = sprites[1];
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

        image.sprite = sprites[0];
    }
}
