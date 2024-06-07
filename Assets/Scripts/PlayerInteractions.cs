using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteractions : MonoBehaviour
{
    [SerializeField] private Image crosshairImage;
    [SerializeField] private Sprite chNormal;
    [SerializeField] private Sprite chInteract;
    [SerializeField] private LayerMask interactMask;
    [SerializeField] private float raycastDistance = 10f;
    [SerializeField] KeyCode interactKey = KeyCode.E;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance, interactMask))
        {
            if (hit.collider == null)
            {
                if (crosshairImage.sprite != chNormal) { crosshairImage.sprite = chNormal; }
            } 
            else
            {
                if (crosshairImage.sprite != chInteract) { crosshairImage.sprite = chInteract; }

                if (Input.GetKeyDown(interactKey))
                {
                    Debug.Log(hit.collider.gameObject.name);
                    Debug.DrawRay(transform.position, transform.forward * raycastDistance, Color.green, 1);

                    Interactable interactable = hit.collider.GetComponent<Interactable>();

                    if (interactable && interactable.canInteract)
                    {
                        interactable.Interact();
                    } 
                    else
                    {
                        Debug.DrawRay(transform.position, transform.forward * raycastDistance, Color.red, 1);
                    }
                }
            }
        }
        else
        {
            if (crosshairImage.sprite != chNormal) { crosshairImage.sprite = chNormal; }
        }
    }
}
