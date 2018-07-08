using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SaveLoadFrame : MonoBehaviour {

	public int frameNumber;

	public string CharacterName;
	public string SceneName;
	public int sceneNumber;

	System.TimeSpan currentCompareTime;
	//System.DateTime startTime;

	public void Start()
	{
		
		//startGameTime;
	}

	public void SetSaveLoadFrame()
	{

	}

	public void ShowData()
	{
		Debug.Log (FSLocator.saveLoadManager.GetSceneNumber (frameNumber));
		switch (FSLocator.saveLoadManager.GetSceneNumber(frameNumber)) {
		case 2:
			SceneName = "Mark Tutoral";

			gameObject.transform.Find ("Time").gameObject.GetComponent<Text> ().fontSize = 60; 
			gameObject.transform.Find ("SceneName").gameObject.GetComponent<Text> ().text = "Chapter1";
			gameObject.transform.Find ("Character").gameObject.SetActive (true);
			gameObject.transform.Find ("Character").gameObject.GetComponent<Image> ().sprite = gameObject.transform.parent.GetComponent<SaveLoadDisplayer> ().Mark;
			break;
		case 3:
			SceneName = "Stacey Tutoral";

			gameObject.transform.Find ("Time").gameObject.GetComponent<Text> ().fontSize =  60;
			gameObject.transform.Find ("SceneName").gameObject.GetComponent<Text> ().text = "Chapter1";
			gameObject.transform.Find ("Character").gameObject.SetActive (true);
			gameObject.transform.Find ("Character").gameObject.GetComponent<Image> ().sprite = gameObject.transform.parent.GetComponent<SaveLoadDisplayer> ().Stacey;
			break;
		case 4:
			SceneName = "Night Scene";

			gameObject.transform.Find ("Time").gameObject.GetComponent<Text> ().fontSize = 60;
			gameObject.transform.Find ("SceneName").gameObject.GetComponent<Text> ().text = "Chapter2";
			gameObject.transform.Find ("Character").gameObject.SetActive (true);
			gameObject.transform.Find ("Character").gameObject.GetComponent<Image> ().sprite = gameObject.transform.parent.GetComponent<SaveLoadDisplayer> ().Mark;
			break;
		case 5:
			SceneName = "Test";

			gameObject.transform.Find ("Time").gameObject.GetComponent<Text> ().fontSize = 60;
			gameObject.transform.Find ("SceneName").gameObject.GetComponent<Text> ().text = "Chapter5";
			gameObject.transform.Find ("Character").gameObject.SetActive (true);
			gameObject.transform.Find ("Character").gameObject.GetComponent<Image> ().sprite = gameObject.transform.parent.GetComponent<SaveLoadDisplayer> ().Stacey;
			break;
		default:
			gameObject.transform.Find ("Time").gameObject.GetComponent<Text> ().text = "저장된 기록 없음";
			gameObject.transform.Find ("Time").gameObject.GetComponent<Text> ().fontSize = 45;
			gameObject.transform.Find ("Character").gameObject.SetActive (false);
			gameObject.transform.Find ("SceneName").gameObject.GetComponent<Text> ().text = "";
			return;
		};

		float time = FSLocator.saveLoadManager.GetPlayTime (frameNumber);

		string hour = ((int)time / 3600).ToString("D2");
		string minute = ((int)time / 60 % 60).ToString("D2");
		string second = ((int)time % 60).ToString("D2");
		gameObject.transform.Find ("Time").gameObject.GetComponent<Text> ().text = hour + ":" + minute + ":" + second;
	}

	public void SaveData()
	{
		FSLocator.saveLoadManager.DeleteData (frameNumber);

		currentCompareTime = System.DateTime.Now - FSLocator.dataObject.startGameTime;

		//Debug.Log ((float)currentCompareTime.TotalSeconds);

		float totalTime = (float)currentCompareTime.TotalSeconds + FSLocator.dataObject.playedTime;

		FSLocator.saveLoadManager.SetSaveData (frameNumber, SceneManager.GetActiveScene ().buildIndex, totalTime);

		FSLocator.saveLoadManager.SaveFile (frameNumber);

		sceneNumber = FSLocator.saveLoadManager.GetSceneNumber(frameNumber);
		//currentCompareTime = FSLocator.saveLoadManager.GetPlayTime ();

		ShowData ();
	}

	public void LoadData()
	{
		FSLocator.saveLoadManager.LoadFile (frameNumber);

		sceneNumber = FSLocator.saveLoadManager.GetSceneNumber(frameNumber);
		//currentCompareTime = FSLocator.saveLoadManager.GetPlayTime (frameNumber);

		if (sceneNumber == 0)
			return;

		FSLocator.dataObject.isLoaded = true;

		FSLocator.dataObject.ContinueTime (FSLocator.saveLoadManager.GetPlayTime (frameNumber));

		GameObject.FindWithTag ("ChangeSceneManager").GetComponent<ChanageSceneManager> ().Fade (FSLocator.saveLoadManager.GetSceneNumber (frameNumber));
	}
}
