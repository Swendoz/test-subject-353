using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [Header("Audio Settings")]
    public AudioMixer audioMixer;
    public Slider masterSlider;
    public Slider muiscSlider;
    public Slider voiceSlider;

    [Header("Resolution Settings")]
    public TMP_Dropdown resolutionDropdown;
    private Resolution[] resolutions;


    void Start()
    {
        // Volume Ayarý
        if (PlayerPrefs.HasKey("Master"))
        {
            float savedVolume = PlayerPrefs.GetFloat("Master");
            masterSlider.value = savedVolume;
            SetMaster(savedVolume);
        } 
        else
        {
            masterSlider.value = 0.8f;
            SetMaster(0.8f);
        }

        if (PlayerPrefs.HasKey("Voice"))
        {
            float savedVolume = PlayerPrefs.GetFloat("Voice");
            voiceSlider.value = savedVolume;
            SetVoice(savedVolume);
        }
        else 
        {
            voiceSlider.value = 0.5f;
            SetVoice(0.5f);
        }


        if (PlayerPrefs.HasKey("Music"))
        {
            float savedVolume = PlayerPrefs.GetFloat("Music");
            muiscSlider.value = savedVolume;
            SetMusic(savedVolume);
        }
        else
        {
            muiscSlider.value = 0.35f;
            SetMusic(0.35f);
        }

        // Çözünürlük Ayarý
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        resolutionDropdown.onValueChanged.AddListener(delegate { SetResolution(resolutionDropdown.value); });
    }

    public void SetMaster(float volume)
    {
        if (volume <= 0.001f)
        {
            volume = 0.0001f;
            audioMixer.SetFloat("Master", -80);
        }
        else
            audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);

        PlayerPrefs.SetFloat("Master", volume);
    }

    public void SetMusic(float volume)
    {
        if (volume <= 0.001f)
        {
            volume = 0.0001f;
            audioMixer.SetFloat("Music", -80);
        }
        else
            audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);

        PlayerPrefs.SetFloat("Music", volume);
    }

    public void SetVoice(float volume)
    {
        if (volume <= 0.001f)
        {
            volume = 0.0001f;
            audioMixer.SetFloat("Voice", -80);
        }
        else
            audioMixer.SetFloat("Voice", Mathf.Log10(volume) * 20);

        PlayerPrefs.SetFloat("Voice", volume);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetSensivity(float sensivityValue)
    {
        Debug.Log("Sensivity: " + sensivityValue);
        PlayerPrefs.SetFloat("Sensivity", sensivityValue);

        PlayerCamera playerCamera = FindObjectOfType<PlayerCamera>();
        if (playerCamera != null)
        {
            Debug.Log("Bulduk bobus");
            playerCamera.sensivity = GameObject.Find("SensivitySlider").GetComponent<Slider>().value;
        }
    }
    
    public void CloseSettings()
    {
        gameObject.SetActive(false);
    }
}
