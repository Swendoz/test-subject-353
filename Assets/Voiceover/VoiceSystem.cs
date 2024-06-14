using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class VoiceSystem : MonoBehaviour
{
    [SerializeField] private bool playOnAwake = false;
    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] private int currentClip = 0;
    public bool isFinished = false;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (playOnAwake)
        {
            StartCoroutine(PlaySound());
        }
    }

    public IEnumerator PlaySound()  
    {
        isFinished = false;
        audioSource.clip = audioClips[currentClip];
        audioSource.Play();
        Debug.Log("Length: " + audioClips[currentClip].length);
        yield return new WaitForSeconds(audioClips[currentClip].length);
        isFinished = true;
        Debug.Log("Finished");
    }

    public void PlayClip(AudioClip clip) 
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void StopSound()
    {
        Debug.Log("Stopping");
        audioSource.Stop(); 
    }

    public void NextSound()
    { 
        currentClip++;
        PlaySound();
    }
}
