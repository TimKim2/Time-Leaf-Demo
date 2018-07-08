using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcEventMaster : MonoBehaviour {

	public List<MoveAroundNpc> moveAroundNpcList;
	public List<MoveAllAround> moveAllAroundNpcList;

	public void AllNpcEventOff()
	{
		for (int i = 0; i < moveAroundNpcList.Count; i++) {
			moveAroundNpcList [i].OnEvent ();
		}

		for (int i = 0; i < moveAllAroundNpcList.Count; i++) {
			moveAllAroundNpcList [i].OnEvent ();
		}
	}

	public void AllNpcEventOn()
	{
		for (int i = 0; i < moveAroundNpcList.Count; i++) {
			moveAroundNpcList [i].OffEvent ();
		}

		for (int i = 0; i < moveAllAroundNpcList.Count; i++) {
			moveAllAroundNpcList [i].OffEvent ();
		}
	}
}
