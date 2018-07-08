using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing_DelItem2 : MonoBehaviour { // 테스트용 온클릭함수
    public int id  ;
    public void DelItem2(int id)
    {
        Debug.Log("삭제를 원하는 아이템의 ID : " + id);
        Inventory.instance.DeleteItem(id);

    }
}
