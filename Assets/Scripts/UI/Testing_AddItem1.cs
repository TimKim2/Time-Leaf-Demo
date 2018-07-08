using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing_AddItem1 : MonoBehaviour { // 테스트용 온클릭함수
    public int id ;
    public void AddItem1(int id)
    {
        Debug.Log("추가를 원하는 아이템의 ID : " + id);
        Inventory.instance.AddItem(id);
    }
}
