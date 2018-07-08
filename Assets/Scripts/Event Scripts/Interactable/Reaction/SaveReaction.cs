using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveReaction : DelayReaction {

	protected override void ImmediateReaction ()
	{
		GameObject.Find ("UI Canvas/SaveLoadDisplayer").transform.Find("SavePopUp").gameObject.SetActive (true);

	}
}
