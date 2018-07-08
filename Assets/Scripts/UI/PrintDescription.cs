using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintDescription : MonoBehaviour {
    public GameObject descriptionPanel; // 설명창 키고 끄기 위해
    public ItemDatabase database; // 데이터베이스 

    public void PrintDes(int id) // 인자로 넘겨받은 id를 기준으로해서
    {
        Debug.Log("호출됬따");
        descriptionPanel.SetActive(true); // 일단 설명창을 켜고 
        Item item = database.FetchItemByID(id); // 받은 id로
        descriptionPanel.transform.GetChild(0).GetComponentInChildren<Text>().text = item.Description;
        descriptionPanel.transform.GetChild(1).GetComponent<Image>().sprite = item.Sprite;
        descriptionPanel.transform.GetChild(2).GetComponent<Text>().text = item.Title;
      //  obj.transform.GetChild(2).GetComponent<Image>().sprite = item.Sprite;
    }

}
