using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestionManager : MonoBehaviour
{
    public static QuestionManager instance;

    [SerializeField] private QuestionData[] questions;
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private Button[] buttons;
    [SerializeField] private GameObject[] lights;
    [SerializeField] private int correctAnswers = 0;
    [SerializeField] private int currentQuestion = 0;
    [SerializeField] private SpotlightsManager spotlightsManager;
    [SerializeField] private AudioClip correctSound;
    [SerializeField] private AudioClip wrongSound;
    [SerializeField] LevelController22 levelController;
    [SerializeField] private AudioClip[] wrongClips;
    [SerializeField] private AudioClip[] correctClips;
    [SerializeField] private AudioSource voiceOver;
    private AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            // DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // GetQuestion();
    }

    public void GetQuestion()
    {
        if (correctAnswers >= 6)
        {
            levelController.OpenDoor();
        }

        if (questions.Length <= currentQuestion && correctAnswers < 6)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (questions.Length <= currentQuestion || questions[currentQuestion].question == null || questions[currentQuestion].question == "") return;

        questionText.text = questions[currentQuestion].question;

        for (int i = 0; i < buttons.Length; i++)
        {
            bool isCorrect = questions[currentQuestion].correctAnswers.Contains(i);
            buttons[i].UpdateText(questions[currentQuestion].answers[i], isCorrect);
        }
    }

    public void CheckQuestion(bool isCorrect)
    {
        int randomWill = Mathf.Min(Random.Range(0, 5));
        bool willVoiceOver = randomWill > 3;
        Debug.Log("Will Voice Over: " +  willVoiceOver);
        Debug.Log("Random Will: " + randomWill);

        if (isCorrect)
        {
            Debug.Log("Yes good");
            audioSource.clip = correctSound;
            if (willVoiceOver)
            {
                int randomVoice = Mathf.RoundToInt(Random.Range(0, correctClips.Length));
                Debug.Log("Random Voice: " + randomVoice);
                voiceOver.clip = correctClips[randomVoice];
            }
            correctAnswers++;
            spotlightsManager.SetGreen();
            UpdateLights();
        } 
        else
        {
            audioSource.clip = wrongSound;
            spotlightsManager.SetRed();
            Debug.Log("Not good");
            if (willVoiceOver)
            {
                
                int randomVoice = Mathf.RoundToInt(Random.Range(0, wrongClips.Length));
                Debug.Log("Random Voice: " + randomVoice);
                voiceOver.clip = wrongClips[randomVoice];
            }
            // Give red things
        }

        NextQuestion();
        audioSource.Play();
        if (willVoiceOver)
        {
            voiceOver.Play();
            Debug.Log("Played Voice Over");
        }
    }

        private void NextQuestion()
    {
        currentQuestion++;
        GetQuestion();
    }

    private void GoQuestion(int goQuestion)
    {
        currentQuestion = goQuestion;
        GetQuestion();
    }

    private void UpdateLights()
    {
        for (int i = 0; i < correctAnswers; i++)
        {
            if (correctAnswers > 6)
            {
                return;
            }
            lights[i].SetActive(true);
        }
    }
}
