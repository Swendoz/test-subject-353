using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScifiDoorTrigger : MonoBehaviour
{
    private Animator _animator;
    private ScifiDoor scifiDoor;
    [SerializeField] private bool triggerClose = true;
    [SerializeField] private bool isWorked = false;
    [SerializeField] private BoxCollider blocker;
    [SerializeField] private LevelController levelController = null;

    void Start()
    {
        _animator = gameObject.GetComponentInParent<Animator>();
        scifiDoor = gameObject.GetComponentInParent<ScifiDoor>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Trigger") && other.gameObject.CompareTag("PlayerCollider"))
        {
            if (_animator != null && !isWorked)
            {
                Debug.Log("Triggerd");
                blocker.isTrigger = false;
                scifiDoor.ToggleDoor(!triggerClose);
                isWorked = true;

                if (levelController)
                {
                    Debug.Log("Level Controller GO");
                    levelController.TriggerDetected();
                }
            }
        }
    }
}
