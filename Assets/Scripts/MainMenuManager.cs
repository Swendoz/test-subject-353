using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject settingsObject;
    [SerializeField] private GameObject controlsObject;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenSettings()
    {
        settingsObject.SetActive(true);
    }
   
    public void OpenControls()
    {
        controlsObject.SetActive(true);
    }

    public void CloseControls()
    {
        controlsObject.SetActive(false);
    }
}
