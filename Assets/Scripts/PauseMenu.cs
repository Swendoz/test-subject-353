using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private KeyCode pauseKey = KeyCode.Escape;
    [SerializeField] private bool isOpen = false;

    private void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            if (isOpen)
            {
                CloseMenu();
                CloseSettings();
            } 
            else
            {
                OpenMenu();
            }
        }
    }

    public void OpenMenu()
    {
        pauseMenu.SetActive(true);
        isOpen = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        AudioListener.pause = true;
        Time.timeScale = 0;
    }

    public void CloseMenu()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        isOpen = false;
        AudioListener.pause = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void OpenSettings()
    {
        settingsMenu.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsMenu.SetActive(false);
    }

    public void QuitGame()
    {
        // Quite the game
        Application.Quit();
    }
}
