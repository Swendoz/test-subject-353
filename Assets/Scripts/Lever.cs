using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private bool isOpen = false;
    [SerializeField] private ScifiDoor scifiDoor;
    private AudioSource audioSource;
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void ToggleDoor()
    {
        isOpen = !isOpen;

        _animator.SetBool("isOpen", isOpen);
        audioSource.Play();

        if (scifiDoor)
        {
            scifiDoor.ToggleDoor(isOpen);
            // doorAnimator.SetBool("isOpen", isOpen);
        }
    }
}
