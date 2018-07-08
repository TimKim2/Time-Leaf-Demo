using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSavePopup : MonoBehaviour {

	public GameObject SavePopUp;
	public GameObject FirstEvent;

	// Use this for initialization
	void Start () {
		

		if (FSLocator.dataObject.isLoaded == true) {
			SavePopUp.SetActive (false);
			FirstEvent.SetActive (true);
		} else if (FSLocator.dataObject.isLoaded == false) {
			FirstEvent.SetActive (false);
			SavePopUp.SetActive (true);
		}
		
		FSLocator.dataObject.SetLoadedFalse ();

		GameObject.FindWithTag ("ChangeSceneManager").GetComponent<ChanageSceneManager> ().FadeIn ();

	}

}
