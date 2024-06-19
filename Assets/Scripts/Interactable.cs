using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    public bool canInteract = true;
    [SerializeField] private Interacts interact;

    enum Interacts
    {
        door, 
        box,
        lever,
        button,
        skipButton
    }

    public void Interact()
    {
        Debug.Log("Interacted");

        switch (interact)
        {
            case Interacts.door:
                Door door = gameObject.GetComponent<Door>();
                door.ToggleDoor();
                break;
            case Interacts.box:
                Debug.Log("Box");
                break;
            case Interacts.lever:
                Lever lever = gameObject.GetComponent<Lever>();
                lever.ToggleDoor();
                break;
            case Interacts.button:
                Button button = gameObject.GetComponent<Button>();
                button.ClickButton();
                break;
            case Interacts.skipButton:
                SkipButton skipButton = gameObject.GetComponent<SkipButton>();
                skipButton.ClickButton();
                break;
            default:
                Debug.Log("WTF WTF WTF WTF");
                break;
        }
    }
}
