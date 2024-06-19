using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class LevelScreens : MonoBehaviour
{
    [SerializeField] private Animator levelAnimator;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private PlayableDirector timeline;
    [SerializeField] private bool canTimeline = true;

    private void Start()
    {
        timeline.enabled = canTimeline;
    }

    public void SetTexts(int currentLevel)
    {
        Debug.Log("Current Level is:" + currentLevel);

        switch (currentLevel)
        {
            case 3:
                levelText.text = "Level 1";
                titleText.text = "Basic Brain Functions";
                break;
            case 5:
                levelText.text = "Level 2";
                titleText.text = "Movement Skills";
                break;
            /*case 7:
                levelText.text = "Level 3";
                titleText.text = "Problem Solving Skills";
                break;*/
            default:
                levelText.text = "";
                titleText.text = "";
                break;
        }
    }
}
