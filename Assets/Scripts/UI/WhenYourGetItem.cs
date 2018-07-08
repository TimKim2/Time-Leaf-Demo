using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenYourGetItem : MonoBehaviour {
    public GameObject getItem;

    public void WhenYouPressThis()
    {
        getItem.SetActive(false);
    }
}
