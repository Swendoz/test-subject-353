using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class LevelController2Maze : LevelController
{
    [SerializeField] private VoiceSystem voiceSystem;
    [SerializeField] private AudioClip voiceForWaiting; // maybe more clips and make it array
    [SerializeField] private bool isVoiceWaitingDone = false;
    [SerializeField] private bool isMazePlaying = false;
    [SerializeField] private bool isMazeFinished = false;
    [SerializeField] private float waitTime = 90f;
    [SerializeField] private float timer = 0; // make it private
    [SerializeField] private GameObject mazeCamera;


    void Start()
    {
        timer = waitTime;
    }

    private void Update()
    {
        if (timer > 0 && !isMazeFinished && isMazePlaying)
        {
            timer -= Time.deltaTime;
        }
        else if (timer <= 0 && !isMazeFinished && isMazePlaying)
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
        mazeCamera.SetActive(true);
    }

    public override void TriggerDetectedFunction(string functionName)
    {
        switch (functionName)
        {
            case "startMaze":
                Debug.Log("Start Maze Triggerd");
                isMazePlaying = true;
                break;
            case "endMaze":
                Debug.Log("End Maze Triggerd");
                isMazeFinished = true;
                break;
            default:
                Debug.Log("How can this happen?");
                break;
        }
    }
}
