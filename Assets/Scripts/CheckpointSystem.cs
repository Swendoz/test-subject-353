using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSystem : MonoBehaviour
{
    public int currentLevel = 0;
    public float dieCounter = 0;
    public Transform currentSpawnpos;
    [SerializeField] private Animator dieAnimator;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject[] skipButtons;
    [SerializeField] private KeyCode restartKey = KeyCode.R;
    [SerializeField] private bool canRestart = true;
    [SerializeField] private float restartTimer = 5f;
    private float timer;

    [Header("sa")]
    [SerializeField] private VoiceSystem voiceSystem;
    [SerializeField] private AudioClip[] goodParkourVoices;
    [SerializeField] private AudioClip[] badParkourVoices;
    [SerializeField] private AudioClip[] buttonAddedVoices;


    private void Start()
    {
        timer = restartTimer;

        for (int i = 0; i < skipButtons.Length; i++)
        {
            skipButtons[i].SetActive(false);
        }
    }

    private void Update()
    {
        if (!canRestart && timer > 0)
        {
            timer -= Time.deltaTime;
        } 
        else if (!canRestart && timer < 0)
        {
            canRestart = true;
            timer = restartTimer;
        }

        if (Input.GetKey(restartKey) && currentSpawnpos != null && canRestart)
        {
            DieSelf();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            CheckpointDoor checkpoint = other.transform.GetComponent<CheckpointDoor>();
            if (checkpoint != null)
            {
                if (currentLevel < checkpoint.level)
                {
                    /*
                    int randomWill = Mathf.Min(Random.Range(0, 5));
                    bool willVoiceOver = randomWill > 3;
                    if (willVoiceOver)
                    {
                        int randomVoice = Mathf.Min(Random.Range(0, goodParkourVoices.Length));
                        voiceSystem.PlayClip(goodParkourVoices[randomVoice]);
                    }*/
                    RandomVoice(goodParkourVoices);

                    // Voice in chance
                    dieCounter = 0;
                    currentLevel = checkpoint.level;
                    currentSpawnpos = checkpoint.spawnpointPos;
                }
            }
        }

        if (other.gameObject.CompareTag("ParkourDie"))
        {
            StartCoroutine(Die());
        }
    }

    private void DieSelf()
    {
        if (canRestart)
        {
            Debug.Log("Die Self");
            canRestart = false;
            StartCoroutine(Die());
        }
    }

    public IEnumerator Die()
    {
        /*
        int randomWill = Mathf.Min(Random.Range(0, 5));
        bool willVoiceOver = randomWill > 3;
        if (willVoiceOver)
        {
            int randomVoice = Mathf.Min(Random.Range(0, badParkourVoices.Length));
            voiceSystem.PlayClip(badParkourVoices[randomVoice]);
        }*/
        RandomVoice(badParkourVoices);

        dieAnimator.SetTrigger("Die");
        yield return new WaitForSeconds(0.5f);
        dieCounter++;
        player.transform.position = currentSpawnpos.position;
        Physics.SyncTransforms(); 
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        if (dieCounter > 5)
        {
            int randomVoice = Mathf.Min(Random.Range(0, buttonAddedVoices.Length));
            voiceSystem.PlayClip(buttonAddedVoices[randomVoice]);

            Debug.Log("Brother You Died So Many Times Now Open");
            dieCounter = 0;

            for (int i = 0; i < currentLevel; i++)
            {
                Debug.Log("OMG: " + i);

                if (currentLevel <= skipButtons.Length)
                {
                    Debug.Log("Yes");
                    skipButtons[i].SetActive(true);
                }
            }
        }
    }

    private void RandomVoice(AudioClip[] voices)
    {
        int randomWill = Mathf.Min(Random.Range(0, 5));
        bool willVoiceOver = randomWill > 3;
        Debug.Log("Will Voice Over: " + willVoiceOver + " + " + randomWill);
        if (willVoiceOver)
        {
            Debug.Log("Worked Random Voice");
            int randomVoice = Mathf.Min(Random.Range(0, voices.Length));
            voiceSystem.PlayClip(voices[randomVoice]);
        }
    }
}
