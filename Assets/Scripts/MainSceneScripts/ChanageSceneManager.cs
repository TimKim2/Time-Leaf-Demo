using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

//using UnityEngine.SceneManagement;

public class ChanageSceneManager : MonoBehaviour {

	public FadeDisplayer m_fadeDisplayer;
	public AudioSource audioSource;
	public AudioClip audioClip;
	public GameObject image;

	float currentVolume;
	//public MasterVolume m_masterVolume;

	public Color fadeColor = new Color(0, 0, 0, 1);

    public void Fade()
	{
		image.SetActive (true);
		audioSource.clip = audioClip;
		audioSource.volume = 1.0f;
		audioSource.PlayDelayed (0);
		m_fadeDisplayer.FadeOut(fadeColor, 3.0f);
		StartCoroutine (SoundFadeIn (4.0f));
		//StartCoroutine (DelayTimeA());
		StartCoroutine(DelayTime());
	}

	public void Fade(int sceneNumber)
	{
		image.SetActive (true);
		audioSource.clip = audioClip;
		audioSource.volume = 1.0f;
		audioSource.PlayDelayed (0);
		m_fadeDisplayer.FadeOut(fadeColor, 4.0f);
		StartCoroutine (SoundFadeIn (5.0f));
		//StartCoroutine (DelayTimeA());
		StartCoroutine(DelayTime(sceneNumber));
	}

	public void FadeIn()
	{
		image.SetActive (true);
		m_fadeDisplayer.FadeIn (fadeColor, 3.0f);
		StartCoroutine (DelayTimeForFadeIn ());
	}

    public void AppQuit()
    {
        image.SetActive(true);
        audioSource.clip = audioClip;
        audioSource.volume = 1.0f;
        audioSource.PlayDelayed(0);
        m_fadeDisplayer.FadeOut(fadeColor, 3.0f);
        StartCoroutine(SoundFadeIn(5.0f));
        StartCoroutine(QuitCoroutine());
    }

    IEnumerator QuitCoroutine()
    {
        yield return new WaitForSeconds(4.0f);

        Application.Quit();
    }

    public IEnumerator DelayTime()
	{
		yield return new WaitForSeconds (3.5f);

		image.SetActive (false);
		AudioListener.pause = true;
		AudioListener.volume = currentVolume;
		SceneManager.LoadScene("TutorialMark");
		//AudioListener.pause = false;
		//Debug.Log ("!!");
	}

	public IEnumerator DelayTime(int sceneNumber)
	{
		yield return new WaitForSeconds (3.5f);

		image.SetActive (false);
		AudioListener.pause = true;
		AudioListener.volume = currentVolume;
		SceneManager.LoadScene(sceneNumber);

		//AudioListener.pause = false;
		//Debug.Log ("!!");
	}

	public IEnumerator DelayTimeForFadeIn()
	{
		yield return new WaitForSeconds (3.0f);

		image.SetActive (false);
	}

	private IEnumerator SoundFadeIn(float fadeTime)
	{
		float currentTime = Time.time;
		currentVolume = AudioListener.volume;
		Debug.Log ("is again?");

		while (currentTime + fadeTime >= Time.time) {
			AudioListener.volume -= (Time.deltaTime) / fadeTime;
			yield return null;
		}

		Debug.Log ("Is Go?");
		//AudioListener.volume = currentVolume;
	}
}
