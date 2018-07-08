using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
	void Start ()
    {
        Handheld.PlayFullScreenMovie("Bridge_Opening_7602.mp4", Color.black, FullScreenMovieControlMode.Hidden, FullScreenMovieScalingMode.Fill);
        SceneManager.LoadScene(1);
	}
}
