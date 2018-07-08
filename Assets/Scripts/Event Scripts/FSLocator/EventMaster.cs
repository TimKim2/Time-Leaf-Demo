using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMaster : MonoBehaviour {

	public List<Interactable> EventList;

	// Use this for initialization
	void Start () {

		for (int i = 0; i < EventList.Count; i++) {
			if (EventList [i] != null) {
				if (EventList [i].isSkip) {
					for (int j = 0; j < EventList [i].conditionCollections.Length; j++) {
						EventList [i].conditionCollections [j].SkipReaction ();
					}
				}
			}
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ForSave()
	{
		for (int i = 0; i < EventList.Count; i++) {
			for (int j = 0; j < EventList [i].conditionCollections.Length; j++) {
				
			}
		}
	}
}
