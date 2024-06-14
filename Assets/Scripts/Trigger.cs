using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] private bool isWorked = false;
    [SerializeField] private LevelController levelController = null;
    [SerializeField] private string functionName = null;

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Trigger") && other.gameObject.CompareTag("PlayerCollider"))
        {
            if (!isWorked)
            {
                Debug.Log("Triggerd");
                isWorked = true;

                if (levelController && functionName != null)
                {
                    Debug.Log("Level Controller GO");
                    levelController.TriggerDetectedFunction(functionName);
                }
            }
        }
    }
}
