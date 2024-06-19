 using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField] private Transform moveObject;
    [SerializeField] private Transform startPos;
    [SerializeField] private Transform endPos;
    [SerializeField] private float speed = 3f;
    [SerializeField] private float startDelay = 0f;
    [SerializeField] private float delay = 0f;

    private bool isStarted = false;
    private bool movingToEnd = true;
    private bool isWaiting = false;


    private void Update()
    {
        if (isWaiting) return;

        if (!isStarted)
        {
            StartCoroutine(IsStarted());
        } 
        else
        {
            if (movingToEnd)
                MoveTowards(endPos);
            else
                MoveTowards(startPos);

            if (Vector3.Distance(moveObject.position, endPos.position) < 0.1f)
                StartCoroutine(WaitAndSwitchDirection(false));
            else if (Vector3.Distance(moveObject.position, startPos.position) < 0.1f)
                StartCoroutine(WaitAndSwitchDirection(true));
        }
    }
    void MoveTowards(Transform target)
    {
        moveObject.position = Vector3.MoveTowards(moveObject.position, target.position, speed * Time.deltaTime);
    }

    IEnumerator WaitAndSwitchDirection(bool moveToEnd)
    {
        isWaiting = true;
        yield return new WaitForSeconds(delay);
        movingToEnd = moveToEnd;
        isWaiting = false;
    }

    IEnumerator IsStarted()
    {
        yield return new WaitForSeconds(startDelay);
        isStarted = true;
    }
}
