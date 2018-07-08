using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


public class SaveLoadManager : MonoBehaviour {

	[Serializable]
	public class SaveDatas
	{
		public int sceneNumber;
		public float playTime;
	}

	public List<bool> conditionList = new List<bool> ();
	public List<bool> challengeList = new List <bool>();
	public List<bool> itemList = new List<bool>();

	public SaveDatas saveData1;
	public SaveDatas saveData2;
	public SaveDatas saveData3;
	public SaveDatas saveData4;

	public void Start()
	{
		//LoadDataForShow ();
		//PlayerPrefs.DeleteAll();
	}

	public void SetSaveData1(int sceneNumber, float playTime)
	{
		saveData1 = new SaveDatas ();
		saveData1.sceneNumber = sceneNumber;
		saveData1.playTime = playTime;
	}

	public void SetSaveData2(int sceneNumber, float playTime)
	{
		saveData2 = new SaveDatas ();
		saveData2.sceneNumber = sceneNumber;
		saveData2.playTime = playTime;
	}

	public void SetSaveData3(int sceneNumber, float playTime)
	{
		saveData3 = new SaveDatas ();
		saveData3.sceneNumber = sceneNumber;
		saveData3.playTime = playTime;
	}

	public void SetSaveData4(int sceneNumber, float playTime)
	{
		saveData4 = new SaveDatas ();
		saveData4.sceneNumber = sceneNumber;
		saveData4.playTime = playTime;
	}

	public void SetSaveData (int number, int sceneNumber, float playTime)
	{
		switch (number) {
		case 1:
			saveData1 = new SaveDatas ();
			saveData1.sceneNumber = sceneNumber;
			saveData1.playTime = playTime;
			break;
		case 2:
			saveData2 = new SaveDatas ();
			saveData2.sceneNumber = sceneNumber;
			saveData2.playTime = playTime;
			break;
		case 3:
			saveData3 = new SaveDatas ();
			saveData3.sceneNumber = sceneNumber;
			saveData3.playTime = playTime;
			break;
		case 4:
			saveData4 = new SaveDatas ();
			saveData4.sceneNumber = sceneNumber;
			saveData4.playTime = playTime;
			break;
		default:
			return;
		}
	}

	public int GetSceneNumber(int number)
	{
		switch (number) {
		case 1:
			return saveData1.sceneNumber;
		case 2:
			return saveData2.sceneNumber;
		case 3:
			return saveData3.sceneNumber;
		case 4:
			return saveData4.sceneNumber;
		default:
			return 0;
		}
	}

	public float GetPlayTime(int number)
	{
		switch (number) {
		case 1:
			return saveData1.playTime;
		case 2:
			return saveData2.playTime;
		case 3:
			return saveData3.playTime;
		case 4:
			return saveData4.playTime;
		default:
			return 0;
		}
	}

	public void DeleteData(int number)
	{
		switch (number) {
		case 1:
			saveData1 = null;
			break;
		case 2:
			saveData2 = null;
			break;
		case 3:
			saveData3 = null;
			break;
		case 4:
			saveData4 = null;
			break;
		default:
			return;
		}
	}

    public void SaveFile(int number)
    {
		SaveDatas saveData;
		switch (number) {
		case 1:
			saveData = saveData1;
			break;
		case 2:
			saveData = saveData2;
			break;
		case 3:
			saveData = saveData3;
			break;
		case 4:
			saveData = saveData4;
			break;
		default:
			return;
		}

		var binaryFormatter = new BinaryFormatter();
		var memoryStream = new MemoryStream();

		binaryFormatter.Serialize(memoryStream, saveData);
		PlayerPrefs.DeleteKey ("SaveData" + number);
		PlayerPrefs.SetString("SaveData" + number, Convert.ToBase64String(memoryStream.GetBuffer()));
	

		for (int i = 0; i < AllConditions.Instance.conditions.Length; i++) {
			PlayerPrefs.SetString("SaveCondition" + i + number, AllConditions.Instance.conditions[i].satisfied.ToString());
		}

		for (int i = 0; i < FSLocator.checkChallenge.iscompleted.Length; i++) {
			PlayerPrefs.SetString("SaveChallenge" + i + number, FSLocator.checkChallenge.iscompleted[i].ToString());
		}

		for (int i = 0; i < AllItemSaveDatas.Instance.itemSaveDatas.Length; i++) {
			PlayerPrefs.SetString ("SaveItemList" + i + number, AllItemSaveDatas.Instance.itemSaveDatas [i].satisfied.ToString ());
		}
    }

	public void LoadDataForShow()
	{
		var data = PlayerPrefs.GetString("SaveData" + 1);

		if (!string.IsNullOrEmpty (data)) {
			var binaryFormatter = new BinaryFormatter ();
			var memoryStream = new MemoryStream (Convert.FromBase64String (data));

			saveData1 = (SaveDatas)binaryFormatter.Deserialize (memoryStream);
		}

		var data2 = PlayerPrefs.GetString("SaveData" + 2);

		if (!string.IsNullOrEmpty (data2)) {
			var binaryFormatter = new BinaryFormatter ();
			var memoryStream = new MemoryStream (Convert.FromBase64String (data2));

			saveData2 = (SaveDatas)binaryFormatter.Deserialize (memoryStream);

			Debug.Log ("SaveLoad??");
		}

		Debug.Log (saveData2.sceneNumber);

		var data3 = PlayerPrefs.GetString("SaveData" + 3);

		if (!string.IsNullOrEmpty (data3)) {
			var binaryFormatter = new BinaryFormatter ();
			var memoryStream = new MemoryStream (Convert.FromBase64String (data3));

			saveData3 = (SaveDatas)binaryFormatter.Deserialize (memoryStream);
		}

		var data4 = PlayerPrefs.GetString("SaveData" + 4);

		if (!string.IsNullOrEmpty (data4)) {
			var binaryFormatter = new BinaryFormatter ();
			var memoryStream = new MemoryStream (Convert.FromBase64String (data4));

			saveData4 = (SaveDatas)binaryFormatter.Deserialize (memoryStream);
		}

	}

    public void LoadFile(int number)
	{
			// 가져온 데이터를 바이트 배열로 변환하고
			// 사용하기 위해 다시 리스트로 캐스팅해줍니다.
		int count = 0;
		
		while (PlayerPrefs.HasKey ("SaveCondition" + count + number) == true) {

			string condition = PlayerPrefs.GetString ("SaveCondition" + count + number);

			if (!string.IsNullOrEmpty(condition))
			{
				bool conditionSatisfied = System.Convert.ToBoolean (condition);
				AllConditions.Instance.conditions [count].satisfied = conditionSatisfied;
				count++;
			}
		}

		count = 0;

		while (PlayerPrefs.HasKey ("SaveChallenge" + count + number) == true) {

			string challenge = PlayerPrefs.GetString ("SaveChallenge" + count + number);
		
			if (!string.IsNullOrEmpty(challenge))
			{
				bool challegeIscomplete = System.Convert.ToBoolean (challenge);
				FSLocator.checkChallenge.iscompleted[count] = challegeIscomplete;
				count++;
			}
		}

		count = 0;

		while (PlayerPrefs.HasKey ("SaveItemList" + count + number) == true) {
			string item = PlayerPrefs.GetString ("SaveItemList" + count + number);

			if (!string.IsNullOrEmpty (item)) {
				bool itemSatisfied = System.Convert.ToBoolean (item);
				AllItemSaveDatas.Instance.itemSaveDatas [count].satisfied = itemSatisfied;
				count++;
			}
		}
		AllItemSaveDatas.Instance.ResetOnlyItems ();


    }
}
