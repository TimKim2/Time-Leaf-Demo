using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneTemporary : MonoBehaviour {

    public void LoadSomething()
    {
        Debug.Log("Click");
        SceneManager.LoadScene("Tutorials");
    }

    public void QuitSomething()
    {
        Application.Quit();
    }
}
