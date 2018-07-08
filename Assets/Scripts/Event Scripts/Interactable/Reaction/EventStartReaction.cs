using UnityEngine;

public class EventStartReaction : DelayedReaction
{
    protected override void ImmediateReaction()
    {
        //스크린 버튼 활성화
        FSLocator.controlManager.m_Button.enabled = true;
        //플레이어 통제 (수정 요망)
        //FSLocator.controlManager.m_Player.move_sp = 0;          //(문워크 가능!!!!미래에 고쳐놔 미래의 나여!! ><)
        //조이스틱 통제 (수정 요망)
        FSLocator.controlManager.m_Joystick.OffJoystick();
		FSLocator.controlManager.m_JoyStickPanel.SetActive (false);
        //UI버튼 비활성화
        FSLocator.controlManager.m_UIObj.SetActive(false);


		//FSLocator.npcEventMaster.AllNpcEventOff ();

        //상호작용 버튼 비활성화
        FSLocator.controlManager.m_InteractableButton.SetActive(false);

        FSLocator.controlManager.EventIsPlaying = true;
    }
}