using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIOption : MonoBehaviour
{
    public ChanageSceneManager changeSceneMgr;

    public void Quit()
    {
        changeSceneMgr.Fade();
        Application.Quit();
    }

    public void MainScene()
    {
        SceneManager.LoadScene(1);
    }
}
