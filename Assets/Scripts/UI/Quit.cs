using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour {

	public void Exit()
	{
		Debug.Log ("Is Exit?");

		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPaused = false;
		#else
		Application.Quit ();
		#endif
	}
}
