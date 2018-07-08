using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterVolume : MonoBehaviour {
    // Update is called once per frame\
	public void Start()
	{

	}

    public void ChangeMastervolume ( )
    {
        float volume = gameObject.GetComponent<Slider>().value;
        AudioListener.volume = volume;
    }
}
