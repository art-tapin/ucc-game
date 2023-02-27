using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnswersData : MonoBehaviour
{
    public bool isCorrect = false;
    public int index;
    public QuizManager quizManager;
    
    public void Answer()
    {
        quizManager.changeColour(index);
        quizManager.isSelected = true;
        quizManager.pressedButtonIndex = index;
        /*
        if (isCorrect)
        {
            Debug.Log("Not Selected - Correct");
            quizManager.correct();
        }
        else
        {
            Debug.Log("Not Selected - Incorrect");
            quizManager.incorrect();
        }*/
    }
     
}
