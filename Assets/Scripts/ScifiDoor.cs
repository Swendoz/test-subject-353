using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScifiDoor : MonoBehaviour
{
    private Animator _animator;
    private AudioSource audioSource;
    [SerializeField] private AudioClip openSound;
    [SerializeField] private AudioClip closeSound;

    void Start()
    {
        _animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void ToggleDoor(bool isOpen)
    {
        _animator.SetBool("isOpen", isOpen);

        if (isOpen)
        {
            audioSource.clip = openSound;
            Invoke(nameof(PlaySound), 1f);
        } 
        else
        {
            audioSource.clip = closeSound;
            Invoke(nameof(PlaySound), 0.1f);
        }
    }

    private void PlaySound()
    {
        audioSource.Play();
    }
}
