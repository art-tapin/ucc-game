using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Questions[] _questions = null;
    public Questions[] Questions { get { return _questions; } }

    private List<int> FinishedQUestions = new List<int>();
    private int currentQuestion = 0;
    private int score;

    void Display()
    {
        //Display Question
        //Display Answers
        //Display Timer
    }

}
