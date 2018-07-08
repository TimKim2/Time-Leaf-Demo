using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class ChallengeMgr : MonoBehaviour
{
    [HideInInspector]
    public bool[] challist = new bool[23];
    public GameObject[] chal;
    public bool isStacy = false;

    public CheckChallenge check;

    private void Start()
    {
		if(GameObject.Find("CheckChallenge")){
			check = GameObject.Find("CheckChallenge").GetComponent<CheckChallenge>();
		}

        if (check)
        {
            for (int i = 0; i < challist.Length; i++)
            {
                challist[i] = check.iscompleted[i];
            }
        }
    }

    void OnDestroy()
    {
		if (FSLocator.dataObject) {
			if (FSLocator.dataObject.isLoaded == false) {
				for (int i = 0; i < challist.Length; i++) {
					check.iscompleted [i] = challist [i];
				}
			}
		}
    }
}
