using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSystem : MonoBehaviour
{
    public static LevelSystem instance;
    [SerializeField] private int currentLevel = 1;
    [SerializeField] private string[] levels;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public void GoLevel(int level)
    {
        if (currentLevel == level) return;
        currentLevel = level;
        SetLevel();
    }

    public void NextLevel()
    {
        Debug.Log("Omg");
        currentLevel++;
        SetLevel();
    }

    private void SetLevel()
    {
        SceneManager.LoadScene(levels[currentLevel - 1]);
    }
}
