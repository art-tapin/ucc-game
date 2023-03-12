using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Questions // : ScriptableObject
{
    public string Question;
    public bool keepCorrectAnswer;
    public string[] Answers;
    public int CorrectAnswer;
}
