using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InterviewQuizManager : MonoBehaviour
{
    public List<Question1> questions;
    public GameObject[] options;
    public int currentQuestionIndex;
    public static bool isIncorrect = false;
    public bool isSelected = false;    

    public TextMeshProUGUI QuestionText;
    public TextMeshProUGUI incorrectText;
    private TextMeshProUGUI selected;
    public GameObject incorrectButton;
    public GameObject questionCanvas;
    //public AudioSource audioSource;

/*
    public GameObject player;
    public SpriteRenderer sittingPlayer;
    public Camera cam1;
    public Camera cam2;*/

    public int pressedButtonIndex = -1;
    [SerializeField] private Button pressedButton;


    IEnumerator playSound(float seconds/*, AudioClip sound*/)
    {
        yield return new WaitForSeconds(seconds);
        //AudioSource.PlayClipAtPoint(sound, transform.position);
    }
    
    //disable blinking of button and revert the colour to white
    IEnumerator revertColor(float seconds, GameObject CAB)
    {
        yield return new WaitForSeconds(seconds);
        StartCoroutine(playSound(2));
        //play sound incorrect

        CAB.GetComponent<Image>().color = Color.white;
        CAB.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.white; 
        TextMeshProUGUI text = CAB.GetComponentInChildren<TextMeshProUGUI>();
        TextBlink textBlink = text.GetComponent<TextBlink>();
        textBlink.enabled = false;
        correct();    
        enableButtons();    
    }

    GameObject changeCorrectAnswerColor()
    {
        int q = questions[currentQuestionIndex].CorrectAnswer;
        GameObject correctAnswerButton = options[q-1];
        correctAnswerButton.GetComponent<Image>().color = Color.green;
        correctAnswerButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.green; 
        // play correct sound
        TextMeshProUGUI text = correctAnswerButton.GetComponentInChildren<TextMeshProUGUI>();
        TextBlink textBlink = text.GetComponent<TextBlink>();
        textBlink.enabled = true;
        disableButtons();
        return correctAnswerButton;
    }


    public void correct()
    {
        //remove the question from the list
        questions.RemoveAt(currentQuestionIndex);
        generateQuestion();
        // play sound
    }

    
    public void incorrect()
    {
        GameObject correctAnswerButton = changeCorrectAnswerColor();
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
        // Play sound here        
        if (toContinue)
        {
            System.Threading.Thread.Sleep(2000);
            //change the correct answer to different index
            if (questions[currentQuestionIndex].CorrectAnswer == pressedButtonIndex+1 &&
                questions[currentQuestionIndex].keepCorrectAnswer == false)

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
                options[pressedButtonIndex].GetComponent<AnswersData1>().isCorrect = false;
            }
            incorrect();
        }
        else
        {
            enableButtons();
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
     
    void Update()
    {
        if (isSelected && pressedButtonIndex >= 0)
        {
            pressedButton = options[pressedButtonIndex].GetComponent<Button>();      
            pressedButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.red;
            pressedButton.GetComponent<Image>().color = Color.red;
            disableButtons(); 
        }   
    }

    private void Start()
    {
        generateQuestion();
        /*
        cam1.enabled = true;
        cam2.enabled = false;*/
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswersData1>().isCorrect = false;
            options[i].GetComponent<AnswersData1>().index = i;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = questions[currentQuestionIndex].Answers[i];
            if (questions[currentQuestionIndex].CorrectAnswer == i+1)
            {
                options[i].GetComponent<AnswersData1>().isCorrect = true;
            }
        }
    }
    
    void generateQuestion()
    {
        if (questions.Count > 0)
        {
            //currentQuestionIndex = Random.Range(0, questions.Count);
            currentQuestionIndex = 0;
            QuestionText.text = questions[currentQuestionIndex].Question;
            SetAnswers();
        }
        else 
        {
            questionCanvas.SetActive(false);
            /*
            player.GetComponent<PlayerMovement>().enabled = true;
            player.GetComponent<SpriteRenderer>().enabled = true;
            cam1.enabled = true;
            cam2.enabled = false;
            sittingPlayer.GetComponent<SpriteRenderer>().enabled = false;
            audioSource.Stop();*/
        }
    }
}
