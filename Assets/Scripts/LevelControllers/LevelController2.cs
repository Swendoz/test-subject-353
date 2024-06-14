using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class LevelController2 : LevelController
{
    [SerializeField] private VoiceSystem voiceSystem;
    [SerializeField] private QuestionManager _questionManager; // make it private
    [SerializeField] private AudioClip voiceForWaiting; // maybe more clips and make it array
    [SerializeField] private bool isVoiceWaitingDone = false;
    [SerializeField] private bool isTriggered = false;
    [SerializeField] private float waitTime = 5f;
    [SerializeField] private float timer = 0; // make it private

    void Start()
    {
        _questionManager = QuestionManager.instance;
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

    public override void TriggerDetected()
    {
        isTriggered = true;
        _questionManager.GetQuestion();
    }
}
