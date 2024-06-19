using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class LevelController22 : LevelController
{
    [SerializeField] private bool isTriggered = false;
    [SerializeField] private ScifiDoor scifiDoor;
    private MusicManager musicManager;

    private void Start()
    {
        musicManager = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicManager>();
    }

    public void OpenDoor()
    {
        if (!isTriggered)
        {
            isTriggered = true;
            scifiDoor.ToggleDoor(true);
        }
    }

    public override void TriggerDetected()
    {
        isTriggered = true;
        musicManager.StartFadeOut();
    }
}

/*
public class LevelController22 : LevelController
{
    [SerializeField] private VoiceSystem voiceSystem;
    [SerializeField] private AudioClip voiceForWaiting; // maybe more clips and make it array
    [SerializeField] private bool isVoiceWaitingDone = false;
    [SerializeField] private bool isTriggered = false;
    [SerializeField] private float waitTime = 5f;
    [SerializeField] private float timer = 0; // make it private
    [SerializeField] private ScifiDoor scifiDoor;
    [SerializeField] private AudioClip[] correctVoice;
    [SerializeField] private AudioClip[] wrongVoice;

    void Start()
    {
        timer = waitTime;
    }

    private void Update()
    {
        if (timer > 0 && !isTriggered)
        {
            timer -= Time.deltaTime;
        }
        else if (timer <= 0 && !isTriggered)
        {
            if (!isVoiceWaitingDone)
            {
                isVoiceWaitingDone = true;
                TimerDoneWaiting();
            }
        }
    }

    private void TimerDoneWaiting()
    {
        Debug.Log("Timer finished");
        voiceSystem.PlayClip(voiceForWaiting);
    }

    public void OpenDoor()
    {
        scifiDoor.ToggleDoor(true);
    }

    public override void TriggerDetected()
    {
        isTriggered = true;
    }
}
*/