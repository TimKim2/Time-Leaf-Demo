using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiPlot : MonoBehaviour
{
    public GameObject toMark;
    public GameObject toStacey;

    Interactable markInteractable;
    Interactable staceyInteractable;

    bool isStacey;
    bool cooltime;

    float t;

    public void Change()
    {
        if (cooltime)
            return;

        if (!isStacey)
            staceyInteractable.Interact();
        else
            markInteractable.Interact();

        isStacey = !isStacey;

        cooltime = true;
    }

	void Start ()
    {
        markInteractable = toMark.GetComponent<Interactable>();
        staceyInteractable = toStacey.GetComponent<Interactable>();
	}

    private void Update()
    {
        if(cooltime)
        {
            t += Time.deltaTime;

            if(t > 1.5f)
            {
                cooltime = false;
                t = 0f;
            }
        }
    }
}
