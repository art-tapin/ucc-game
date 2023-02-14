using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public List<Questions> questions;
    public GameObject[] options;
    public int currentQuestionIndex;
    public static bool isIncorrect = false;
    

    public TextMeshProUGUI QuestionText;
    public TextMeshProUGUI incorrectText;
    public GameObject nextButton;
    public GameObject incorrectButton;
    public GameObject questionCanvas;

    public void correct()
    {
        questions.RemoveAt(currentQuestionIndex);
        generateQuestion();
    }

    public void incorrect()
    {
        int insultsIndex;
        string[] insults = {"Try again!", "You're not very good at this"};
        insultsIndex = Random.Range(0, insults.Length);
        string incorrectText = insults[insultsIndex];
        isIncorrect = true;
        setIncorrectText(incorrectText);
    }

    public void setIncorrectText(string text)
    {
        incorrectText.text = text;
        incorrectButton.SetActive(true);
    }
    
    void Update()
    {
        if (isIncorrect && Input.GetMouseButtonDown(0))
        {
            incorrectButton.SetActive(false);
        }
    }

    private void Start()
    {
        generateQuestion();
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            //options[i].GetComponent<AnswersData>().IsCorrect = questions[currentQuestionIndex].CorrectAnswer == i ? true : false;
            options[i].GetComponent<AnswersData>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = questions[currentQuestionIndex].Answers[i];
            //options[i].GetComponent<AnswersData>().questionTextObject.text = questions[currentQuestionIndex].Answers[i];
            if (questions[currentQuestionIndex].CorrectAnswer == i+1)
            {
                options[i].GetComponent<AnswersData>().isCorrect = true;
            }
        }
    }
    
    void generateQuestion()
    {
        if (questions.Count > 0)
        {
            if (questions.Count == 1)
            {
                nextButton.SetActive(false);
            }
            currentQuestionIndex = Random.Range(0, questions.Count);
            QuestionText.text = questions[currentQuestionIndex].Question;
            SetAnswers();
        }
        else 
        {
            questionCanvas.SetActive(false);
        }
        
    }
}
