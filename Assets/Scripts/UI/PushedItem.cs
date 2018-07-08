using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PushedItem : MonoBehaviour {
    public void pushed()
    {
        Debug.Log("pushed Item ! Send Message ! ");
          GameObject.FindGameObjectWithTag("InventorySystem").SendMessage("PrintDes", gameObject.GetComponent<ItemData>().item.ID);
        // 인벤토리안에있는 아이템을 누르면 이제 함수를 실행 시킨다.
    }
}
