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

    public TextMeshProUGUI QuestionText;

    public void correct()
    {
        questions.RemoveAt(currentQuestionIndex);
        generateQuestion();
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
        currentQuestionIndex = Random.Range(0, questions.Count);
        QuestionText.text = questions[currentQuestionIndex].Question;
        SetAnswers();
    }
}
