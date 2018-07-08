using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DataObjectForOtherScene : MonoBehaviour {

	public AudioSource audioSource;

	public System.DateTime startGameTime;
	public float playedTime = 0;

	public bool isLoaded = false;

	//private static bool created = false;

	private static DataObjectForOtherScene m_DataObject;

	public static DataObjectForOtherScene dataObject
	{
		get{

			if (!m_DataObject) {
				m_DataObject = FindObjectOfType<DataObjectForOtherScene> ();
			}
			return m_DataObject;
		}
	}


	// Use this for initialization
	void Awake () {

		//Debug.Log ("Awake?");
		if (FindObjectsOfType<DataObjectForOtherScene> ().Length < 2) {
			DontDestroyOnLoad (this.gameObject);
			startGameTime = System.DateTime.Now;
			Debug.Log ("Is Create?");
		}
	}

	public void SetLoadedFalse()
	{
		isLoaded = false;
	}

	public void StartTime()
	{
		startGameTime = System.DateTime.Now;
		playedTime = 0;
	}

	public void ContinueTime(float playedTime)
	{
		this.playedTime = playedTime;
	}
}
