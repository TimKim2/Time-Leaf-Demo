using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSLocator
{

    public static TextDisplayer textDisplayer
    {
        get
        {
            if (!m_textDisplayer)
            {
                m_textDisplayer = GameObject.FindObjectOfType<TextDisplayer>();
            }

            return m_textDisplayer;
        }
    }

    private static TextDisplayer m_textDisplayer;



    private static CharacterDisplayer m_characterDisplayer;


    public static CharacterDisplayer characterDisplayer
    {
        get
        {
            if (!m_characterDisplayer)
            {
                m_characterDisplayer = GameObject.FindObjectOfType<CharacterDisplayer>();
            }
            return m_characterDisplayer;
        }
    }


    private static BackgroundDisplayer m_backgroundDisplayer;


    public static BackgroundDisplayer backgroundDisplayer
    {
        get
        {
            if (!m_backgroundDisplayer)
            {
                m_backgroundDisplayer = GameObject.FindObjectOfType<BackgroundDisplayer>();
            }
            return m_backgroundDisplayer;
        }
    }


    private static FadeDisplayer m_fadeDisplayer;
    public static FadeDisplayer fadeDisplayer
    {
        get
        {
            if (!m_fadeDisplayer)
            {
                m_fadeDisplayer = GameObject.FindObjectOfType<FadeDisplayer>();
            }
            return m_fadeDisplayer;
        }
    }

    private static ControlManager m_controlManager;
    public static ControlManager controlManager
    {
        get
        {
            if (!m_controlManager)
            {
                m_controlManager = GameObject.FindObjectOfType<ControlManager>();
            }
            return m_controlManager;
        }
    }

    private static ChoiceDisplayer m_choiceDisplayer;
    public static ChoiceDisplayer choiceDisplayer
    {
        get
        {
            if(!m_choiceDisplayer)
            {
                m_choiceDisplayer = GameObject.FindObjectOfType<ChoiceDisplayer>();
            }
            return m_choiceDisplayer;
        }
    }

    private static Timer m_timer;
    public static Timer timer
    {
        get
        {
            if (!m_timer)
            {
                m_timer = GameObject.FindObjectOfType<Timer>();
            }
            return m_timer;
        }
    }

    private static CutSceneTextDisplayer m_cutSceneTextDisplayer;


    public static CutSceneTextDisplayer cutSceneTextDisplayer
    {
        get
        {
            if (!m_cutSceneTextDisplayer)
            {
                m_cutSceneTextDisplayer = GameObject.FindObjectOfType<CutSceneTextDisplayer>();
            }
            return m_cutSceneTextDisplayer;
        }
    }

    private static ChallengeMgr m_challengeMgr;

    public static ChallengeMgr challengeMgr
    {
        get
        {
            if(!m_challengeMgr)
            {
                m_challengeMgr = GameObject.FindObjectOfType<ChallengeMgr>();
            }

            return m_challengeMgr;
        }
    }

    private static MiniMapMgr m_MinimapMgr;

    public static MiniMapMgr minimapMgr
    {
        get
        {
            if(!m_MinimapMgr)
            {
                m_MinimapMgr = GameObject.FindObjectOfType<MiniMapMgr>();
            }

            return m_MinimapMgr;
        }
    }

	private static EventMaster m_EventMaster;

	public static EventMaster eventMaster
	{
		get {
			if (!m_EventMaster) {
				m_EventMaster = GameObject.FindObjectOfType<EventMaster> ();
			}
			return m_EventMaster;
		}
	}

	private static NpcEventMaster m_NpcEventMaster;

	public static NpcEventMaster npcEventMaster
	{
		get {
			if (!m_NpcEventMaster) {
				m_NpcEventMaster = GameObject.FindObjectOfType<NpcEventMaster> ();
			}
			return m_NpcEventMaster;
		}
	}

	private static OnOffQuest m_onoffQuest;

	public static OnOffQuest onoffQuest
	{
		get
		{
			if (!m_onoffQuest)
			{
				m_onoffQuest = GameObject.FindObjectOfType<OnOffQuest>();
			}
			return m_onoffQuest;
		}
	}

	private static Quest m_questMgr;

	public static Quest questMgr
	{
		get
		{
			if (!m_questMgr)
			{
				m_questMgr = GameObject.FindObjectOfType<Quest>();
			}
			return m_questMgr;
		}
	}

	private static CheckChallenge m_checkChel;

	public static CheckChallenge checkChallenge
	{
		get {
			if (!m_checkChel) {
				m_checkChel = GameObject.FindObjectOfType<CheckChallenge> ();
			}
			return m_checkChel;
		}
	}

	private static SaveLoadManager m_SaveLoadManager;

	public static SaveLoadManager saveLoadManager
	{
		get{
			if(!m_SaveLoadManager){
				m_SaveLoadManager = GameObject.FindObjectOfType<SaveLoadManager> ();
			}
			return m_SaveLoadManager;
		}
	}
		
	private static DataObjectForOtherScene m_DataObject;

	public static DataObjectForOtherScene dataObject
	{
		get{
			if (!m_DataObject) {
				m_DataObject = GameObject.FindObjectOfType<DataObjectForOtherScene> ();
			}
			return m_DataObject;
		}
	}
}
