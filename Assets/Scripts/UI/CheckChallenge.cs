using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckChallenge : MonoBehaviour
{
    public bool[] iscompleted = new bool[23];

    GameObject go;
    CheckScore checkScore;

    void Awake()
    {
        if(GameObject.FindObjectsOfType<CheckChallenge>().Length < 2)
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void OnDestroy()
    {   
        go = GameObject.Find("CheckScore");

        if(go)
        {
            checkScore = go.GetComponent<CheckScore>();

            for(int i = 0; i < iscompleted.Length; i++)
            {
                if(iscompleted[i] == true)
                {
                    checkScore.checkTrue++;
                }
            }

            //checkScore.Score();
        }
    }
}
