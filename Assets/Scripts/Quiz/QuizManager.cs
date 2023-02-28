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
    public bool isSelected = false;    

    public TextMeshProUGUI QuestionText;
    public TextMeshProUGUI incorrectText;
    private TextMeshProUGUI selected;
    public GameObject confirmingDialogue;
    public GameObject incorrectButton;
    public GameObject questionCanvas;

    public int pressedButtonIndex = -1;
    [SerializeField] private Button pressedButton;


    IEnumerator playSound(float seconds, AudioClip sound)
    {
        yield return new WaitForSeconds(seconds);
        AudioSource.PlayClipAtPoint(sound, transform.position);
    }
    
    IEnumerator revertColor(float seconds, GameObject CAB)
    {
        yield return new WaitForSeconds(seconds);
        playSound(2, CAB.GetComponent<AnswersData>().sound);
        CAB.GetComponent<Image>().color = Color.white;
        CAB.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.white; 
        TextMeshProUGUI text = CAB.GetComponentInChildren<TextMeshProUGUI>();
        TextBlink textBlink = text.GetComponent<TextBlink>();
        textBlink.enabled = false;
        correct();
    }

    GameObject changeCorrectAnswerColor()
    {
        int q = questions[currentQuestionIndex].CorrectAnswer;
        GameObject correctAnswerButton = options[q-1];
        correctAnswerButton.GetComponent<Image>().color = Color.green;
        correctAnswerButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.green; 
        TextMeshProUGUI text = correctAnswerButton.GetComponentInChildren<TextMeshProUGUI>();
        TextBlink textBlink = text.GetComponent<TextBlink>();
        textBlink.enabled = true;
        return correctAnswerButton;
    }

    

    public void correct()
    {
        //disable blinking of button
        questions.RemoveAt(currentQuestionIndex);
        generateQuestion();
    }

    
    public void incorrect()
    {
        GameObject correctAnswerButton = changeCorrectAnswerColor();
        //insert pause
        StartCoroutine(revertColor(3, correctAnswerButton));
    }


    public void setIncorrectText(string text)
    {
        incorrectText.text = text;
        incorrectButton.SetActive(true);
    }

    
    public void continueNotContinue(bool toContinue)
    {
        isSelected = false;     //enables to click buttons again
        changeColour(-1);
        if (toContinue)
        {
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
            selected = pressedButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            selected.color = Color.white;
            pressedButton.GetComponent<Image>().color = Color.white;
        }
    }

    void enableButtons()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Button>().interactable = true;
        }
    }
    
    void disableButtons()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Button>().interactable = false;
        }
    }

    //show the dialogue box to confirm the answer
    public void showConfirmingDialogue()
    {
        if (isSelected && pressedButtonIndex >= 0)
        {
            confirmingDialogue.SetActive(true);  
            pressedButton = options[pressedButtonIndex].GetComponent<Button>();      
            pressedButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.red;
            pressedButton.GetComponent<Image>().color = Color.red;
            disableButtons(); 
        }
        else
        {
            enableButtons();
        }        
    }
        
    
    void Update()
    {
        showConfirmingDialogue();
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
