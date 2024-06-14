using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController1 : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private VoiceSystem voiceSystem;

    // Start is called before the first frame update
    void Start()
    {
       playerMovement.canMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        // No character controller
        // Blind character
        // After 43 seconds
        // Can move, can enter the next level

        if (voiceSystem.isFinished)
        {
            playerMovement.canMove = true;
        }
    }
}
