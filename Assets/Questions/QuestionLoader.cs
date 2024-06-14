using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class QuestionLoader : MonoBehaviour
{
    public QuestionData[] questions;

    void Start()
    {
        LoadQuestions();
    }

    void LoadQuestions()
    {
        /*string filePath = Path.Combine(Application.streamingAssetsPath, "questions.json");
        string json = File.ReadAllText(filePath);

        string[] questionObjects = JsonHelper.GetJsonObjectArray(json, "questions");
        questions = new QuestionData[questionObjects.Length];
       
        for (int i = 0; i < questionObjects.Length; i++)
        {
            questions[i] = JsonUtility.FromJson<QuestionData>(questionObjects[i]);
            Debug.Log("Question " + i + ": " + questions[i].question);
        }
         */

        for (int i = 0; i < questions.Length; i++)
        {
            Debug.Log("Question " + i + ": " + questions[i].question);
        }
    }
}
