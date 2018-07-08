using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMap : MonoBehaviour
{
    public Image[] images;

    public Text floorText;
    public Text science;

    public MiniMapMgr minimapMgr;

    private void OnEnable()
    {
        CheckMiniMap();
    }

    void CheckMiniMap()
    {
        if (minimapMgr.isRoofTop)
        {
            for (int i = 1; i < images.Length; i++)
            {
                if (i == 6 || i == 7)
                    continue;

                images[i].gameObject.SetActive(false);
            }
        }

        else
        {
            for (int i = 1; i < images.Length; i++)
            {
                images[i].gameObject.SetActive(true);
            }
        }

        for (int i = 1; i < images.Length; i++)  //모든 이미지들 흰색으로 초기화
        {
            images[i].color = new Color(1, 1, 1, 1);
        }

        images[minimapMgr.miniMapNum].color = new Color32(255, 100, 100, 255);  //해당 이미지만 빨간색으로 바꿈
        floorText.text = minimapMgr.miniMapStr;

        if (minimapMgr.isSience)
            science.text = "과학실";
        else
            science.text = "음악실";
    }
}
