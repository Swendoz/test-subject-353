using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightsManager : MonoBehaviour
{
    [SerializeField] private Animator[] spotlights;

    public void SetGreen()
    {
        for (int i = 0; i < spotlights.Length; i++)
        {
            spotlights[i].SetTrigger("isCorrect");
        }
    }

    public void SetRed()
    {
        for (int i = 0; i < spotlights.Length; i++)
        {
            spotlights[i].SetTrigger("isWrong");
        }
    }
}
