using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOnOff : MonoBehaviour { // 인벤토리 On Off 버튼 
    public GameObject object_panel;  // 스크롤뷰 연결
    public GameObject uiBackground; // 스크롤뷰가 켜졌을 때 뒤에 깔리는 배경 ( 살짝 불투명한 검은색 )
    public GameObject ui_Panel;
    public GameObject ui_SaveLoad;
    public GameObject ui_Quest;

    public void Set() // OnClik 시 호출되는 함수
    {
        object_panel.SetActive(true); // 스크롤뷰 온 / 오프  
        uiBackground.SetActive(true); // 뒤 배경 온 / 오프 
        //ui_SaveLoad.SetActive(true);
        ui_Panel.SetActive(false); // ui 패널은 꺼지게
        ui_Quest.SetActive(false);
    }
}
