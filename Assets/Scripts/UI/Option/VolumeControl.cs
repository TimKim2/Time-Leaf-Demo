using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour {

    public AudioSource[] audioSource;

    public void SoundControl()
    {
        for(int i = 0; i <audioSource.Length; i++)
        {
            audioSource[i].volume = gameObject.GetComponent<Slider>().value;
        }
    }
}
