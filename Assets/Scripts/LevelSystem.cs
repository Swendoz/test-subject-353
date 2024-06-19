using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSystem : MonoBehaviour
{
    public static LevelSystem instance;
    [SerializeField] private int currentLevel = 1;
    [SerializeField] private string[] levels;
    [SerializeField] private Animator levelAnimator;
    [SerializeField] private LevelScreens levelScreens;
    [SerializeField] private bool isNextLeveling = false;
    private MusicManager musicManager;

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
        if (GameObject.FindGameObjectWithTag("MusicManager") != null)
        {
            musicManager = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicManager>();
        }
        else
            Debug.Log("Music Manager not found");

        Debug.Log("Worked");
        // May not work
        int currentLevelUpdated = SceneManager.GetActiveScene().buildIndex + 1;
        currentLevel = currentLevelUpdated;
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
        if (isNextLeveling) return;

        isNextLeveling = true;
        Debug.Log("Omg");
        currentLevel++;
        StartCoroutine(SetLevel());
    }

    private IEnumerator SetLevel()
    {
        levelAnimator.SetTrigger("endLevel");
        yield return new WaitForSeconds(1);

        if (musicManager != null)
        {
            musicManager.StartFadeOut();
            yield return new WaitForSeconds(musicManager.fadeDuration);
            SceneManager.LoadScene(levels[currentLevel - 1]);
            yield return new WaitForSeconds(1);
            levelScreens = GameObject.FindGameObjectWithTag("LevelScreens").GetComponent<LevelScreens>();
            levelScreens.SetTexts(currentLevel);
            levelAnimator = levelScreens.gameObject.GetComponent<Animator>();
            isNextLeveling = false;
        }
        else
        {
            SceneManager.LoadScene(levels[currentLevel - 1]);
            yield return new WaitForSeconds(1);
            levelScreens = GameObject.FindGameObjectWithTag("LevelScreens").GetComponent<LevelScreens>();
            levelScreens.SetTexts(currentLevel);
            levelAnimator = levelScreens.gameObject.GetComponent<Animator>();
            isNextLeveling = false;
        }
    }
}
