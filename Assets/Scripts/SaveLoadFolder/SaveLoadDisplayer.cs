using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadDisplayer : MonoBehaviour {

	public Sprite Mark;
	public Sprite Stacey;

	public SaveLoadFrame frame1;
	public SaveLoadFrame frame2;
	public SaveLoadFrame frame3;
	public SaveLoadFrame frame4;

	public void ShowFrame()
	{
		FSLocator.saveLoadManager.LoadDataForShow ();
		frame1.ShowData ();
		frame2.ShowData ();
		frame3.ShowData ();
		frame4.ShowData ();
	}
}
