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


   private void Awake()
   {
       yesButton.onClick.AddListener(Continue);
       noButton.onClick.AddListener(NotContinue);
   }

   public void NotContinue()
    {
        Debug.Log("NotContinue");
        quizManager.continueNotContinue(false);
    }

    public void Continue()
    {
        Debug.Log("Continue");
        quizManager.continueNotContinue(true);
    }
}
