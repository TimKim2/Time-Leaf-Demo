using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour { // 인벤토리 총괄 매니저
    public static Inventory instance; // 스태틱을 위한 
    int slotAmount; // 슬롯 개수, 실제로는 유니티상에서 추가해주는 식으로 구현했음 기존에 새로 생성하는 방식에서 바꿈
    public ItemDatabase database;  // ItemDatabase 스크립트로 부터 받아올 것이다.

    //public GameObject inventoryPanel; 
    public GameObject inventoryItem; // 추가될 아이템 프리팹 

    public List<Item> items = new List<Item>(); // 현재 추가된 아이템들에 대한 정보를 저장하고 있을 List
    public List<GameObject> slots = new List<GameObject>(); // slot들과 연동 되어있는 List

    public List<Item> items_clue = new List<Item>(); // 현재 추가된 아이템들에 대한 정보를 저장하고 있을 List
    public List<GameObject> slots_clue = new List<GameObject>(); // slot들과 연동 되어있는 List

    public GameObject getItemPanel; // 아이템 얻었을 때 뜨는 창 

    private void Awake() // static 구현을 위해
    {
        instance = this;
        slotAmount = 15;        
    }

    private void Start() // 테스트를 위해 아이템 다 추가해놓은 것
    {
        // 씬 넘어가고 새롭게 Inventory Start 할때 AllItemSaveDatas.asset 참고해서 불러온다.
        for(int i = 0; i < AllItemSaveDatas.Instance.itemSaveDatas.Length; i++)
        {
            if (AllItemSaveDatas.Instance.itemSaveDatas[i].satisfied)
            {
                AddItem(i);
            }
        }
        //     Debug.Log("자식이 없을때 자식을 부르면 뭐가 출력될까요 ? " + slots[5].transform.GetChild(0)); 오류가 난다.
    }


    public void AddItem(int id) // 역할 : id 값을 넘겨주면 슬롯에 아이템을 추가함
    {
     //   Debug.Log("Catch here");
        Item itemToAdd = database.FetchItemByID(id); // 추가될 아이템의 정보를 id값을 기준으로 찾아줌ㄹㄴㄹㅁ
        
        if ( CheckIfItemIsInventory(itemToAdd) == -1  ) // 만약 슬롯에 아이템이 있는지없는지 체크 없다면 실시 
        {
            if (itemToAdd.Type == 2) // 추가할 아이템은 Bag 에 들어갈 아이템이다.
            {
                items.Add(itemToAdd); // 추가할 아이템을 리스트에 추가
                GameObject itemObj = Instantiate(inventoryItem) as GameObject; // 하이러키 상에 게임오브젝트 추가
                Debug.Log("items.count = " + items.Count);
                itemObj.transform.SetParent(slots[items.Count - 1].transform); // 새로 생성한 오브젝트의 부모는 "현재 리스트의 노드 갯수-1"을 인덱스로해서 그 자식으로 넣음 ( Slot의 자식 )
                itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite; // 새로 생성한 오브젝트의 스프라이트는 읽어온 아이템의 스프라이트로 교체
                itemObj.transform.localPosition = Vector3.zero; // 부모와 같은 scene상 동일 위치 
                itemObj.transform.localScale = new Vector3(0.8f, 0.8f, 1); // 동일 위치에 크기조절 
                itemObj.GetComponent<ItemData>().item = itemToAdd; // 각각 아이템 프리팹이 가지고 있는 스크립트 ItemData의 내부 item의 정보 갱신                
            }
            else
            {
                items_clue.Add(itemToAdd); // 추가할 아이템을 리스트에 추가
                GameObject itemObj = Instantiate(inventoryItem) as GameObject; // 하이러키 상에 게임오브젝트 추가
                itemObj.transform.SetParent(slots_clue[items_clue.Count - 1].transform); // 새로 생성한 오브젝트의 부모는 "현재 리스트의 노드 갯수-1"을 인덱스로해서 그 자식으로 넣음 ( Slot의 자식 )
                itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite; // 새로 생성한 오브젝트의 스프라이트는 읽어온 아이템의 스프라이트로 교체
                itemObj.transform.localPosition = Vector3.zero; // 부모와 같은 scene상 동일 위치 
                itemObj.transform.localScale = new Vector3(0.8f, 0.8f, 1); // 동일 위치에 크기조절 
                itemObj.GetComponent<ItemData>().item = itemToAdd; // 각각 아이템 프리팹이 가지고 있는 스크립트 ItemData의 내부 item의 정보 갱신

            }
            // getItemPanel.SetActive(true); // 아이템 입수시 뜨는 창 활성화
            // getItemPanel.transform.GetChild(0).GetComponent<Text>().text = itemToAdd.Dialogue;
            // getItemPanel.transform.GetChild(1).GetComponent<Image>().sprite = itemToAdd.Sprite;
            // Debug.Log(" items[" + (items.Count-1) + "]'s id :" + itemToAdd.ID + " slug : " + itemToAdd.Slug);
        }
        else
        {
            Debug.Log("이미 있는 아이템 입니다 ! ");
        }
    }
    public void DeleteItem(int id) // 역할 : id 값을 넘겨주면 슬롯에 있는 아이템을 제거함
    {
        Debug.Log("deleteItem func   id : " + id );
        Item itemToRemove = database.FetchItemByID(id); // 마찬가지로 지울 아이템에 대한 정보값을 받아옴 
        int index = CheckIfItemIsInventory(itemToRemove); // 그 아이템이 현재 인벤토리에 있는지없는지 
        Debug.Log("Find index = " + index);
        if (index != -1) // 인벤토리 안에 있다면
        {
            items.Remove(itemToRemove); // 찾은 아이템을 리스트에서 지워버림
            Destroy(slots[index].transform.GetChild(0).gameObject); // 하이러키 상에서 그 아이템 삭제

                while (index < slotAmount - 1 && slots[index + 1].transform.childCount != 0) // 지워진것 기점으로
                { // 한칸씩 앞으로 땅기는 역할
                    Debug.Log("current index = " + index);
                    Transform childNode = slots[index + 1].transform.GetChild(0).GetComponent<Transform>(); 
                    // 옮겨질 노드는 지워진 아이템의 다음 슬롯의 자식 아이템이다.
                    childNode.SetParent(slots[index].transform); // 이 노드를 이제 현재 노드의 자식으로 설정 
                    childNode.localPosition = Vector3.zero; // 마찬가지로 위치랑 
                    childNode.localScale = new Vector3(0.8f, 0.8f, 1); // 크기 재조정
                    index++;
                    if (index == 14) // 끝까지 가면 중지

                    {
                        break;
                    }
                }
        }
        else
        {
            Debug.Log("해당하는 아이템이 없습니다!");
        
        }
    }

    int CheckIfItemIsInventory(Item item) // 아이템이 현재 있나없나 체크한다. 있으면 index 값 없으면 -1 반환
    {
      //  Debug.Log("Check func...current items.count = " + items.Count);
        for(int i = 0; i < items.Count; i++)
        {
            if (items[i].ID == item.ID) // 현재 리스트를 확인하면서 넘겨받은 인자값과 비교해서 찾고자하는게
            { // 맞다면 해당 인덱스를 반환 
                return i;
            }
        }
          return -1;
    }
    int CheckIfItemIsInventory(int id) // 이건 위와 동일 함수인데 id 값만 받았을때 버전이다.
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].ID == id)
                return i;
        }
         return -1;
    }
}
