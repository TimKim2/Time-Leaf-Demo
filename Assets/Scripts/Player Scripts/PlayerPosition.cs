using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour {

	public List<GameObject> playerPositionList;
	public int number = -1;
	private GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		player.transform.position = playerPositionList [number].transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
