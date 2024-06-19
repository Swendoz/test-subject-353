using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource audioSource;
    public float fadeDuration = 2.0f; // Sesin artma/azalma süresi

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource != null)
        {
            Debug.Log("Starting");
            StartCoroutine(FadeIn(audioSource, fadeDuration));
        }
    }

    public IEnumerator FadeIn(AudioSource audioSource, float duration)
    {
        audioSource.volume = 0;
        audioSource.Play();

        float startVolume = 0.1f;

        while (audioSource.volume < 0.5f)
        {
            audioSource.volume += startVolume * Time.deltaTime / duration;

            yield return null;
        }

        audioSource.volume = 0.5f;
    }

    public IEnumerator FadeOut(AudioSource audioSource, float duration)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / duration;

            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }

    public void StartFadeIn()
    {
        StartCoroutine(FadeIn(audioSource, fadeDuration));
    }

    public void StartFadeOut()
    {
        StartCoroutine(FadeOut(audioSource, fadeDuration));
    }
}
