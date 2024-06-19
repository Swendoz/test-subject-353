using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakObject : MonoBehaviour
{
    [SerializeField] private Vector3 restartPos; // Make it private
    [SerializeField] private float delay = 1.5f;
    // [SerializeField] private bool isWorked = false;
    private Rigidbody rb;

    private void Start()
    {
        restartPos = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // isWorked = true;
            Invoke(nameof(BreakIt), delay);
        }
    }

    void BreakIt()
    {
        rb.isKinematic = false;
        StartCoroutine(RestartPosition(2f));
    }

    IEnumerator RestartPosition(float waitRestart)
    {
        yield return new WaitForSeconds(waitRestart);
        // isWorked = false;
        rb.isKinematic = true;
        transform.position = restartPos;
    }
}
