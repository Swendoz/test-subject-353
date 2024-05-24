using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetDevInfos : MonoBehaviour
{
    public GameObject player;

    public Infos infoText;
    public TextMeshProUGUI infoValueText;

    public enum Infos
    {
        speed,
        state,
        onSlope,
        part
    }

    private void Start()
    {
        player = GameObject.FindObjectOfType<PlayerMovement>().gameObject;

        if (player == null)
            Debug.LogError("Player not found - Dev Infos");

        gameObject.transform.Find("InputText").GetComponent<TextMeshProUGUI>().text = ForceFirstUpper(infoText.ToString()) + ":";
        infoValueText = gameObject.transform.Find("InputValue").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        infoValueText.text = CheckInfoValue(infoText);
    }

    private string CheckInfoValue(Infos infotText)
    {
        switch (infotText)
        {
            case Infos.speed:
                return Mathf.Round(player.GetComponent<Rigidbody>().velocity.magnitude).ToString();
            case Infos.state:
                return player.GetComponent<PlayerMovement>().state.ToString();
            case Infos.onSlope:
                return player.GetComponent<PlayerMovement>().OnSlope().ToString();
            default: 
                return "No data for " + infoText;
        }
    }

    public string ForceFirstUpper(string word)
    {
        if (word.Length == 0)
        {
            return word;
        }
        if (word.Length < 2)
        {
            return word.ToUpper();
        }
        return string.Concat(word[0].ToString().ToUpper(), word.Substring(1));
    }
}
