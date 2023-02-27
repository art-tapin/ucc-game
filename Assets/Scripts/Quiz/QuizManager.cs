using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public List<Questions> questions;
    public Button[] options;
    public int currentQuestionIndex;
    public static bool isIncorrect = false;
    public bool isSelected = false;
    
    public TextMeshProUGUI QuestionText;
    public TextMeshProUGUI incorrectText;
    private TextMeshProUGUI selected;
    public GameObject confirmingDialogue;
    public GameObject incorrectButton;
    public GameObject questionCanvas;
    public int pressedButtonIndex = -1;
    [SerializeField] private Button pressedButton;
    //[SerializeField] private Button yesButton;
    //[SerializeField] private Button noButton;

    IEnumerator Delay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }

    public void correct(int qu)
    {
        
        options[qu-1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.white; 
        TextMeshProUGUI text = options[qu-1].GetComponentInChildren<TextMeshProUGUI>();
        TextBlink textBlink = text.GetComponent<TextBlink>();
        textBlink.enabled = false;
        
        Debug.Log("should stop flashing color");

        //questions.RemoveAt(currentQuestionIndex);
        //generateQuestion();
    }

    public void incorrect()
    {
        int q = questions[currentQuestionIndex].CorrectAnswer;
        options[q-1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.green; 
        TextMeshProUGUI text = options[q-1].GetComponentInChildren<TextMeshProUGUI>();
        TextBlink textBlink = text.GetComponent<TextBlink>();
        textBlink.enabled = true;

        //insert pause
        StartCoroutine(Delay(5f));

        correct(q);
        //insert insults
        
        /*
        int insultsIndex;
        string[] insults = {"Try again!", "You're not very good at this"};
        insultsIndex = Random.Range(0, insults.Length);
        string incorrectText = insults[insultsIndex];
        isIncorrect = true;
        setIncorrectText(incorrectText);*/
    }

    public void setIncorrectText(string text)
    {
        incorrectText.text = text;
        incorrectButton.SetActive(true);
    }

    public void continueNotContinue(bool toContinue)
    {
        changeColour(-1);
        if (toContinue)
        {
            Debug.Log("Continue");
            //change the correct answer to different index
            if (questions[currentQuestionIndex].CorrectAnswer == pressedButtonIndex+1)
            {
                switch (pressedButtonIndex)
                {
                    case 0:
                        questions[currentQuestionIndex].CorrectAnswer = 2;
                        break;
                    case 1:
                        questions[currentQuestionIndex].CorrectAnswer = 3;
                        break;
                    case 2:
                        questions[currentQuestionIndex].CorrectAnswer = 4;
                        break;
                    case 3:
                        questions[currentQuestionIndex].CorrectAnswer = 1;
                        break;
                }
                options[pressedButtonIndex].GetComponent<AnswersData>().isCorrect = false;
            }
            incorrect();
        }
    }

    //restarts the unpressed button colour to white
    public void changeColour(int i)
    {
        if (pressedButtonIndex != i && pressedButtonIndex >= 0)
        {
            selected = options[pressedButtonIndex].transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            selected.color = Color.white;
        }
    }
    
    void Update()
    {
        if (isSelected && pressedButtonIndex >= 0)
        {
            confirmingDialogue.SetActive(true); 
            isSelected = false;       
            Debug.Log("Picked an answer");
            options[pressedButtonIndex].transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.red; 
        } 

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
            options[i].GetComponent<AnswersData>().isCorrect = false;
            options[i].GetComponent<AnswersData>().index = i;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = questions[currentQuestionIndex].Answers[i];
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
            /*
            if (questions.Count == 1)
            {
                nextButton.SetActive(false);
            }*/
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
