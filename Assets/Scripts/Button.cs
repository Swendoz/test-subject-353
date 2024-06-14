 using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Button : MonoBehaviour
{
    private Animator _animator;
    private AudioSource audioSource;
    [SerializeField] private string value = "";
    [SerializeField] private bool isCorrect = false;
    [SerializeField] private TextMeshProUGUI textValue;

    [SerializeField] private QuestionManager _questionManager; // make it private

    void Start()
    {
        _questionManager = QuestionManager.instance;
        _animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        UpdateText();
    }

    public void UpdateText(string newValue, bool newIsCorrect)
    {
        value = newValue;
        isCorrect = newIsCorrect;
        textValue.text = value;
    }

    public void UpdateText()
    {
        textValue.text = value;
    }

    public void ClickButton()
    {
        _questionManager.CheckQuestion(isCorrect);

        _animator.SetTrigger("clicked");
        float randomPitch = Random.Range(1, 1.5f);
        audioSource.pitch = randomPitch;
        audioSource.Play();
    }
}
