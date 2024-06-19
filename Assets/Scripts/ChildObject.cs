using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChildObject : MonoBehaviour
{
    /*
    private Transform playerTransform;
    private Vector3 initialOffset;
    private Vector3 lastPlatformPosition;
    private bool isOnPlatform;

    private void Start()
    {
        // Oyuncunun baþlangýçta platforma olan offset'ini kaydet
        if (playerTransform != null)
        {
            initialOffset = playerTransform.position - transform.position;
        }
    }

    private void Update()
    {
        if (isOnPlatform && playerTransform != null)
        {
            // Platformun son pozisyonundan ve baþlangýçtaki offset'ten yola çýkarak oyuncunun yeni pozisyonunu güncelle
            Vector3 platformMovement = transform.position - lastPlatformPosition;
            playerTransform.position += platformMovement;
        }

        // Platformun son pozisyonunu güncelle
        lastPlatformPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerCollider"))
        {
            // Oyuncunun platforma temas ettiðinde
            playerTransform = other.transform.parent;
            lastPlatformPosition = transform.position;
            initialOffset = playerTransform.position - transform.position;
            isOnPlatform = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerCollider"))
        {
            // Oyuncu platformdan ayrýldýðýnda
            playerTransform = null;
            isOnPlatform = false;
        }
    }*/

    /*private Vector3 previousPosition;

    private void Start()
    {
        previousPosition = transform.position;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerCollider"))
        {
            Debug.Log("Oha Chat");
            Rigidbody playerRb = other.transform.parent.transform.gameObject.GetComponent<Rigidbody>();
            if (playerRb != null)
            {
                Vector3 platformVelocity = (transform.position - previousPosition) / Time.fixedDeltaTime;
                previousPosition = transform.position;

                playerRb.velocity = platformVelocity;
            }
        }    
    }*/

    private void Start()
    {
        Debug.Log("sa");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerCollider"))
        {
            Debug.Log("Yes");
            other.transform.parent.transform.SetParent(transform, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerCollider"))
        {
            Debug.Log("No");
            other.transform.parent.transform.SetParent(null);
        }
    }
}
