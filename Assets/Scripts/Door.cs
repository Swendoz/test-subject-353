using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class Door : MonoBehaviour
{
    [SerializeField] private bool isDisabled = false;
    [SerializeField] private bool isOpen = false;
    [SerializeField] private AudioClip openDoor;
    [SerializeField] private AudioClip closeDoor;
    [SerializeField] private AudioClip lockedDoor;
    private bool isOpened = false;

    private Animator animator;
    private Vector3 currentEulerAngle;
    private Quaternion currentRotation;
    private AudioSource audioSource;
    private LevelSystem _levelSystem;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        _levelSystem = LevelSystem.instance;
        animator.SetBool("isOpen", isOpen);

        // go.transform.localRotation = Quaternion.Euler(100f, 100f, 100f);

/*
       if (!isDisabled)
        {
            GameObject doorHinge = transform.Find("doorhinge-0").gameObject;
            Debug.Log(doorHinge.tag);

            if (doorHinge != null)
            {
                // doorHinge.transform.rotation = Quaternion.Euler(-90, 0, -5f);
                currentEulerAngle += new Vector3(-90f, 0, -5f);
                currentRotation.eulerAngles = currentEulerAngle;

                doorHinge.transform.rotation = currentRotation;
                Debug.Log("Oha chat ne diyo bu");
                // Vector3 newRotation = new Vector3(100, 100, 100);
                // doorHinge.transform.eulerAngles = newRotation;
            }

            Debug.Log("Zart zort");

            //transform.Find("doorhinge-0").transform.rotation = Quaternion.Euler(150, 150, -5);
            //transform.Find("doorhinge-0").transform.Rotate(150, 150, -5);
        }*/
    }

    public void ToggleDoor()
    {
        Debug.Log("Toggled door");

        if (isDisabled)
        {
            animator.SetTrigger("isDisabled");
            PlaySound(lockedDoor);
        }
        else
        {
            // Delete it if you will add close functionality
            if (isOpened) return;

            isOpen = !isOpen;
            isOpened = true;

            animator.SetBool("isOpen", isOpen);

            if (isOpen)
            {
                PlaySound(closeDoor);
            } else
            {
                PlaySound(openDoor);
            }
            
            // Go to new level
            _levelSystem.NextLevel();
        }
    }

    private void PlaySound(AudioClip audio)
    {
        audioSource.clip = audio;
        audioSource.Play();
    }
}
