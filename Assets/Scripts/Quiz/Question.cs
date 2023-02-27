using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Questions// : ScriptableObject
{
    public string Question;
    public string[] Answers;
    public int CorrectAnswer;

    /*[SerializeField] private string _questionText = string.Empty;
    public string QuestionText { get { return _questionText; } }

    [SerializeField] Answer[] _answerText = null;
    public Answer[] Answers { get { return _answerText; } }

    //parameters
    [SerializeField] private bool _useTimer = false;
    public bool UseTimer { get { return _useTimer; } }

    [SerializeField] private int _timer = 0;
    public int Timer { get { return _timer; } }

    [SerializeField] private int _addScore = 10;
    public int AddScore { get { return _addScore; } }

    public List<int> GetCorrectAnswer()
    {
        List<int> correctAnswer = new List<int>();
        for (int i = 0; i < Answers.Length; i++)
        {
            if (Answers[i].IsCorrect)
            {
                correctAnswer.Add(i);
            }
        }
        return correctAnswer;
    }*/

}
