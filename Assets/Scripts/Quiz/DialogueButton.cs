using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueButton : MonoBehaviour
{
    public QuizManager quizManager;
    public Button yesButton;
    public Button noButton;

    //public static bool toContinue;


    public void NotContinue()
    {
        quizManager.continueNotContinue(false);
    }

    public void Continue()
    {
        quizManager.continueNotContinue(true);
    }
}
