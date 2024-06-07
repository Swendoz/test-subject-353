using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (player != null)
        {
            Quaternion rotationAngle = Quaternion.LookRotation(player.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotationAngle, Time.deltaTime * 5);
        }
    }
}
