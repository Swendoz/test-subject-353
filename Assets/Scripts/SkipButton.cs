using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipButton : MonoBehaviour
{
    private Animator _animator;
    private AudioSource audioSource;
    [SerializeField] private CheckpointDoor nextCheckpointDoor;
    [SerializeField] private CheckpointSystem checkpointSystem;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void ClickButton()
    {
        Debug.Log("Skip Button CLicked");
        _animator.SetTrigger("clicked");
        float randomPitch = Random.Range(1, 1.5f);
        audioSource.pitch = randomPitch;
        audioSource.Play();

        checkpointSystem.currentLevel = nextCheckpointDoor.level;
        checkpointSystem.currentSpawnpos = nextCheckpointDoor.spawnpointPos;
        checkpointSystem.dieCounter = -1;
        StartCoroutine(checkpointSystem.Die());
    }
}
