using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswersData : MonoBehaviour
{
    /*
    // Instantiate the answers
    [Header("UI Elements")]
    [SerializeField] TextMeshProUGUI questionTextObject;
    [SerializeField] Image toggle;

    [Header("Sprites")]
    [SerializeField] Sprite uncheckedToggle;
    [SerializeField] Sprite checkedToggle;

    private int _answerIndex = -1;
    public int AnswerIndex { get { return _answerIndex; } }
    */
    public bool isCorrect = false;
    public QuizManager quizManager;

    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("Correct");
            quizManager.correct();
        }
        else
        {
            Debug.Log("Incorrect");
            quizManager.incorrect();
        }
    }
     
}
