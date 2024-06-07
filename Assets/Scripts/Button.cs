 using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Button : MonoBehaviour
{
    private Animator _animator;
    private AudioSource audioSource;
    [SerializeField] private string value = "";
    [SerializeField] private TextMeshProUGUI textValue;

    void Start()
    {
        _animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        UpdateText();
    }

    public void UpdateText()
    {
        textValue.text = value;
    }

    public void ClickButton()
    {
        _animator.SetTrigger("clicked");
        float randomPitch = Random.Range(1, 1.5f);
        Debug.Log("Random Pitch: " + randomPitch);
        audioSource.pitch = randomPitch;
        audioSource.Play();
    }
}
