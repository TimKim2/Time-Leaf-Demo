using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAllItemSaveData : MonoBehaviour {

    // Git 실험
    // 초기 스트립터블 오브젝트 설정
    // 모든 조건(ItemSaveData)들을 false로 초기화한다.
    void Start()
    {
        AllItemSaveDatas.Instance.Reset();
    }
}
