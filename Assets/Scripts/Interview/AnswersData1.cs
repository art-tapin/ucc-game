using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnswersData1 : MonoBehaviour
{
    public bool isCorrect = false;
    public int index;
    public InterviewQuizManager quizManager;
    
    public void Answer()
    {
        quizManager.changeColour(index);
        quizManager.isSelected = true;
        quizManager.pressedButtonIndex = index;
        if (isCorrect)
        {
            quizManager.correct();
            Debug.Log("Correct");
        }
        else
        {
            quizManager.incorrect();
            Debug.Log("Incorrect");
        }
    }
     
}
