using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteControl : MonoBehaviour {
    bool isMute = false;
    public Slider volumeController;
    public GameObject checkImage;
    public void Mute()
    {
        isMute = !isMute;
        checkImage.SetActive(isMute);
        if (isMute)
        {
            AudioListener.volume = 0;
        }
        else
        {
            float volume = volumeController.value;
            AudioListener.volume = volume;
        }
    }
}
