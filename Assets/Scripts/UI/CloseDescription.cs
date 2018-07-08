using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDescription : MonoBehaviour { // 설명이 나와있고 어딘가 누르면 설명창 닫기 위해
    public GameObject obj; 

    public void CloseDes() // 끈다. 그렇다 
    {
        obj.SetActive(false);
    }


}
