using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSystem : MonoBehaviour
{
    public static LevelSystem instance;
    [SerializeField] private int currentLevel = 1;
    [SerializeField] private string[] levels;
    [SerializeField] private Animator levelAnimator;
    [SerializeField] private LevelScreens levelScreens;

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

    private void Start()
    {
        levelScreens = GameObject.FindGameObjectWithTag("LevelScreens").GetComponent<LevelScreens>();
        levelScreens.SetTexts(currentLevel);
        levelAnimator = levelScreens.gameObject.GetComponent<Animator>();
    }

    public void GoLevel(int level)
    {
        if (currentLevel == level) return;
        currentLevel = level;
        StartCoroutine(SetLevel());
    }

    public void NextLevel()
    {
        Debug.Log("Omg");
        currentLevel++;
        StartCoroutine(SetLevel());
    }

    private IEnumerator SetLevel()
    {
        levelAnimator.SetTrigger("endLevel");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(levels[currentLevel - 1]);
        levelScreens = GameObject.FindGameObjectWithTag("LevelScreens").GetComponent<LevelScreens>();
        levelScreens.SetTexts(currentLevel);
        levelAnimator = levelScreens.gameObject.GetComponent<Animator>();
    }
}
