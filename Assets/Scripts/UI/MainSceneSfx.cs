using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneSfx : MonoBehaviour
{
    public AudioSource btnSfx;

    public void SoundPlay()
    {
        btnSfx.Play();
    }
}
