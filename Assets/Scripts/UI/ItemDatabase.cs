using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class ItemDatabase : MonoBehaviour {
    private List<Item> database = new List<Item>(); // 모든 아이템 정보들을 보관하고있는 리스트
    private JsonData itemData; // JsonData를 읽어서 1차적으로 담아두기 위한 곳

    private void Start()
    {
        //#if UNITY_EDITOR_WIN
        //       itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json")); // json 파일을 읽어옴
        //#elif UNITY_ANDROID
        string jsn = Resources.Load<TextAsset>("Items").text;
        itemData = JsonMapper.ToObject(jsn);
//#endif
        ConstructItemDatabase(); // database 구축 
    }

    public Item FetchItemByID(int id) // id 로 아이템 찾기 기능
    {
        //Debug.Log("Fetch Item func database.Count = " + database.Count );
        for(int i = 0; i < database.Count; i++) // 리스트를 다 찾아본다.
        {
            if (database[i].ID == id)  // 현재 인덱스의 아이템정보가 찾고자하는 아이템의 ID면 
            {
                //Debug.Log("Fetch Item func  :  Find it ! \n id : " + id );
                return database[i]; // 해당 아이템을 반환한다.
            }
        }
        return null; // 못찾으면 NULL 
    }

    void ConstructItemDatabase() // database 구축
    {
        //Debug.Log("ConsturctItemDatabase !    itemData.Count = " + itemData.Count);
        for (int i = 0; i < itemData.Count; i++) // json 파일을 앞에서부터 파싱해옴
        {
            database.Add(new Item((int)itemData[i]["id"], itemData[i]["title"].ToString(),(int)itemData[i]["type"], (int)itemData[i]["chapter"],itemData[i]["description"].ToString(),
                itemData[i]["dialogue"].ToString(),itemData[i]["slug"].ToString()));  // 리스트에 노드 추가
            //Debug.Log(itemData[i]["id"] +"   \n" + itemData[i]["title"].ToString() + "   \n" + (int)itemData[i]["type"] 
            //    + "   \n" + (int)itemData[i]["chapter"] + "   \n" + itemData[i]["description"] + "   \n" + itemData[i]["dialogue"].ToString()
            //    + "   \n" + itemData[i]["slug"].ToString());
        }
        //Debug.Log("dataBase's size = " + database.Count);

    }
}
// 클래스
public class Item {
    public int ID { get; set; }
    public string Title { get; set; }
    public int Type { get; set; }
    public int Chapter { get; set; }
    public string Description { get; set; }
    public string Dialogue { get; set; }
    public string Slug { get; set; }
    public Sprite Sprite { get; set; }

    public Item(int id, string title, int type, int chapter, string description, string dialogue, string slug) //  생성자다 생성자
    {
        this.ID = id;
        this.Title = title;
        this.Type = type;
        this.Chapter = chapter;
        this.Description = description;
        this.Dialogue = dialogue;
        this.Slug = slug; // 각자 생성자로 초기화
        this.Sprite = Resources.Load<Sprite>("Sprites/Items/" + slug); // Resources 폴더에 있는 스프라이트 불러옴
        //Debug.Log("loaded item complete \n id : " + id + "\nTitle : " + title + "\nDescription " + description + "\nSlug : " + slug );
    }

    public Item() // 만약 인자없이 넘겨지는 아이템이잇다면...이건 잘못된거 오류임
    {
        this.ID = -1;
    }
}

