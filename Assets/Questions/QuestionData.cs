using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Question Data", menuName = "Question Data", order = 51)]
public class QuestionData : ScriptableObject
{
    public int id;
    public string question;
    public string[] answers;
    public int[] correctAnswers;
}
