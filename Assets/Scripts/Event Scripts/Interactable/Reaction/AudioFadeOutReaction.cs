using UnityEngine;
using System.Collections;

public class AudioFadeOutReaction : DelayedReaction
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    [Range(0.0f, 1.0f)]
    public float volume = 0.5f;
    public float fadeTime;

    protected override void ImmediateReaction()
    {
        if (audioClip != null)
            audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.PlayDelayed(delay);
        CoroutineHandler.Start_Coroutine(FadeOutAudio());
    }

    IEnumerator FadeOutAudio()
    {
        while (audioSource.volume > 0)
        {
            audioSource.volume -= volume * (Time.deltaTime / fadeTime);

            yield return null;
        }

        audioSource.Stop();

        GameObject go = GameObject.Find("CoroutineHandler");
        Destroy(go);
    }
}
