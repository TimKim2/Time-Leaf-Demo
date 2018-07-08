using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenTouchButton : MonoBehaviour {

    public float time = 0.0f;

	public void LockButton()
	{
		this.enabled = false;
		StartCoroutine (Cooltime());
	}

	IEnumerator Cooltime()
	{
		yield return new WaitForSeconds (time);
		this.enabled = true;
	}
}
