using UnityEngine;

public class EventEndReaction : DelayedReaction
{
    protected override void ImmediateReaction()
    {
        FSLocator.controlManager.m_Button.onClick.RemoveAllListeners();
        //스크린 버튼 비활성화
        FSLocator.controlManager.m_Button.enabled = false;
        //플레이어 움직임 활성화 (수정 요망)
        // FSLocator.controlManager.m_Player.move_sp = 1.5f;
        //조이스틱 활성화 (수정 요망)
        //FSLocator.controlManager.m_Joystick.OnJoystick();
		FSLocator.controlManager.m_JoyStickPanel.SetActive (true);
        //UI버튼 활성화
        FSLocator.controlManager.m_UIObj.SetActive(true);

        //상호작용 버튼 활성화
        FSLocator.controlManager.m_InteractableButton.SetActive(true);

        //대화 관련된 것들 전부 숨기기
        FSLocator.textDisplayer.HideDialogueHolder();
        FSLocator.characterDisplayer.HideImage();
        FSLocator.backgroundDisplayer.HideBackground();

        //NPC EVENT ON
        //FSLocator.npcEventMaster.AllNpcEventOn ();

        //퀘스트가 바꼈으면 이벤트 끝날때 바꿔줌
        FSLocator.onoffQuest.txt.text = FSLocator.questMgr.queststring;


        FSLocator.controlManager.EventIsPlaying = false;
    }
}