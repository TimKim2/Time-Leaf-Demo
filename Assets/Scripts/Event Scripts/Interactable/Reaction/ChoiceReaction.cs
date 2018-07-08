using UnityEngine;

public class ChoiceReaction : DelayedReaction
{
    public string firstDialogue;
    public ReactionCollection firstReactionCollection;

    public string secondDialogue;
    public ReactionCollection secondReactionCollection;



    protected override void SpecificInit()
    {
    }


    protected override void ImmediateReaction()
    {
		//대화 관련된 것들 전부 숨기기         
		FSLocator.textDisplayer.HideDialogueHolder();         
		FSLocator.characterDisplayer.HideImage();         
		FSLocator.backgroundDisplayer.HideBackground();
        //스크린 버튼 비활성화
        FSLocator.controlManager.m_Button.enabled = false;
        //선택지 보여주기
        FSLocator.choiceDisplayer.ShowDistractor();
        //텍스트 입력
        FSLocator.choiceDisplayer.SetTextToFirstDistractor(firstDialogue);
        //두번째 텍스트 입력
        FSLocator.choiceDisplayer.SetTextToSecondDistractor(secondDialogue);
        //조이스틱 끄기
        FSLocator.controlManager.m_Joystick.OffJoystick();
        //상호작용 버튼 비활성화
        FSLocator.controlManager.m_InteractableButton.SetActive(false);
        //선택지에 다음 리엑션 추가
        FSLocator.choiceDisplayer.firstButton.onClick.AddListener(delegate { SetFirstReaction(); });
        FSLocator.choiceDisplayer.secondButton.onClick.AddListener(delegate { SetSecondReaction(); });
    }

	public override void Skip()
	{
		firstReactionCollection.Skip ();
	}

    void SetFirstReaction()
    {
        //스크린 버튼 활성화
        FSLocator.controlManager.m_Button.enabled = true;

        FSLocator.choiceDisplayer.HideDistractor();
        //선택지 버튼에 함수 제거
        FSLocator.choiceDisplayer.firstButton.onClick.RemoveAllListeners();
        FSLocator.choiceDisplayer.secondButton.onClick.RemoveAllListeners();
        //다음 리액션으로 넘어가기까지 제거
        FSLocator.controlManager.m_Button.onClick.RemoveAllListeners();
        FSLocator.controlManager.m_Button.onClick.AddListener(delegate { firstReactionCollection.React(); });
        firstReactionCollection.React();

    }

    void SetSecondReaction()
    {
        //스크린 버튼 활성화
        FSLocator.controlManager.m_Button.enabled = true;

        FSLocator.choiceDisplayer.HideDistractor();
        FSLocator.choiceDisplayer.firstButton.onClick.RemoveAllListeners();
        FSLocator.choiceDisplayer.secondButton.onClick.RemoveAllListeners();
        FSLocator.controlManager.m_Button.onClick.RemoveAllListeners();
        FSLocator.controlManager.m_Button.onClick.AddListener(delegate { secondReactionCollection.React(); });
        secondReactionCollection.React();
        
    }
}
