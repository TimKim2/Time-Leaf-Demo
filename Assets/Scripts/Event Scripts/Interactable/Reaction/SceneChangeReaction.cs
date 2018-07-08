using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeReaction : DelayedReaction
{
    public string changeSceneStr = "";

    protected override void ImmediateReaction()
    {
        // 씬 바꾸기전에 무조건 인덱스 0~5에 해당되는 아이템(Clue 제외)들은 false로 만들어서 지운다.
        AllItemSaveDatas.Instance.ResetOnlyItems();

        // 씬을 바꾼다.
        SceneManager.LoadScene(changeSceneStr);
    }
}
