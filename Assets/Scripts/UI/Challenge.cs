using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Challenge : MonoBehaviour
{
    public ChallengeMgr challmgr;
    string[] texts = new string[23];
    int idx;
    int panelidx;

	void Start ()
    {
        texts[0] = "분홍색 곰인형의 주인을 찾아줬나요?";
        texts[1] = "이사벨의 부탁을 들어줬나요?";
        texts[2] = "사나토스에 관련된 책을 찾아 읽었나요?";
        texts[3] = "2층 과학실 도우미들과 얘기해봤나요?";
        texts[4] = "팀의 취미에 대해 들은 적이 있나요?";
        texts[5] = "부실한 시계를 발견했나요?";
        texts[6] = "누군가의 핸드폰을 몰래 봤나요?";
        texts[7] = "스테이시에 관한 이야기를 들은 적 있나요?";
        texts[8] = "케빈에게 감자튀김을 받아봤나요?";
        texts[9] = "아이린이 혼자 옥상에서 어떤 일을 했는지 알아냈나요?";
        texts[10] = "케빈이 좋아하는 사람이 누구인지 알아냈나요?";
        texts[11] = "아이린에게 선물을 준 적 있나요?";
        texts[12] = "사건의 범인이 누구인지 알아냈나요?";
        texts[13] = "반장인 사람의 부탁을 들어줬나요?";
        texts[14] = "분실물 센터에 가 봤나요?";
        texts[15] = "케빈에게 안부를 물어본 적이 있나요?";
        texts[16] = "기숙사 304호에 들어간 적이 있나요?";
        texts[17] = "잠겨 있는 캐비넷을 열어봤나요?";
        texts[18] = "찢어진 사진을 발견했나요?";
        texts[19] = "옥상 열쇠를 받았나요?";
        texts[20] = "린차오의 총을 찾았나요?";
        texts[21] = "기억을 되찾았나요?";
        texts[22] = "사건의 범인이 누구인지 알아냈나요?";

        if(challmgr.isStacy == false)
        {
            for (int i = 0; i < challmgr.chal.Length; i++)
            {
                challmgr.chal[i].GetComponentInChildren<Text>().text = texts[i];
            }
        }

        else
        {
            idx = 13;

            for (int i = 0; i < challmgr.chal.Length; i++)
            {
                challmgr.chal[i].GetComponentInChildren<Text>().text = texts[idx];
                idx++;

                if (idx > 22)
                    idx = 0;
            }
        }
    }

    void OnEnable()
    {
        CheckChal();
    }

    void CheckChal()
    {
        if (challmgr.isStacy == false)
        {
            for (int i = 0; i < challmgr.chal.Length; i++)
            {
                challmgr.chal[i].GetComponentInChildren<Text>().text = texts[i];

                if (challmgr.challist[i] == true)
                {
                    challmgr.chal[i].GetComponent<Image>().color = new Color32(255, 255, 255, 100);
                    challmgr.chal[i].GetComponentInChildren<Text>().color = new Color32(255, 255, 255, 100);
                }

                else
                {
                    challmgr.chal[i].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                    challmgr.chal[i].GetComponentInChildren<Text>().color = new Color32(255, 255, 255, 255);
                }
            }
        }

        else
        {
            idx = 13;
            panelidx = 10;

            for (int i = 0; i < challmgr.chal.Length; i++)
            {
                challmgr.chal[i].GetComponentInChildren<Text>().text = texts[idx];

                if (challmgr.challist[i] == true)
                {
                    challmgr.chal[panelidx].GetComponent<Image>().color = new Color32(255, 255, 255, 100);
                    challmgr.chal[panelidx].GetComponentInChildren<Text>().color = new Color32(255, 255, 255, 100);
                }

                else
                {
                    challmgr.chal[panelidx].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                    challmgr.chal[panelidx].GetComponentInChildren<Text>().color = new Color32(255, 255, 255, 255);
                }

                idx++;
                panelidx++;

                if (idx > 22)
                    idx = 0;
                if (panelidx > 22)
                    panelidx = 0;
            }
        }
    }
}
