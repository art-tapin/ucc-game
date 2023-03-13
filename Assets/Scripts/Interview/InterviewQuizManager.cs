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
    public GameObject interviewCanvas;
    public GameObject interviewTrigger;

    public Animator bowserAnim;
    public GameObject player;
    public GameObject bowser;
    public GameObject enemies;

    public int pressedButtonIndex = -1;

    [SerializeField]
    private Button pressedButton;

    //disable blinking of button and revert the colour to white
    IEnumerator revertCorrectAnswerColor(float seconds, GameObject CAB)
    {
        isSelected = false;
        yield return new WaitForSeconds(seconds);
        CAB.GetComponent<Image>().color = Color.white;
        CAB.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.white;
        TextMeshProUGUI text = CAB.GetComponentInChildren<TextMeshProUGUI>();
        TextBlink textBlink = text.GetComponent<TextBlink>();
        textBlink.enabled = false;
        enableButtons();
        //remove the question from the list
        questions.RemoveAt(currentQuestionIndex);
        generateQuestion();
    }

    void revertPressedButtonColor()
    {
        isSelected = false;

        options[pressedButtonIndex].GetComponent<Image>().color = Color.white;
        options[pressedButtonIndex].transform.GetChild(0).GetComponent<TextMeshProUGUI>().color =
            Color.white;
        TextMeshProUGUI text = options[
            pressedButtonIndex
        ].GetComponentInChildren<TextMeshProUGUI>();
        TextBlink textBlink = text.GetComponent<TextBlink>();
        enableButtons();
    }

    GameObject changeCorrectAnswerColor()
    {
        int q = questions[currentQuestionIndex].CorrectAnswer;
        GameObject correctAnswerButton = options[q - 1];
        correctAnswerButton.GetComponent<Image>().color = Color.green;
        correctAnswerButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color =
            Color.green;
        TextMeshProUGUI text = correctAnswerButton.GetComponentInChildren<TextMeshProUGUI>();
        TextBlink textBlink = text.GetComponent<TextBlink>();
        textBlink.enabled = true;
        disableButtons();
        return correctAnswerButton;
    }

    public void correct()
    {
        GameObject correctAnswerButton = changeCorrectAnswerColor();
        StartCoroutine(revertCorrectAnswerColor(3, correctAnswerButton));
        pressedButtonIndex = -1;
    }

    public void incorrect()
    {
        // set incorrect text
        int insultsIndex;
        string[] insults = { "Try again!", "You're not very good at this" };
        insultsIndex = Random.Range(0, insults.Length);
        string incorrectText = insults[insultsIndex];
        isIncorrect = true;
        setIncorrectText(incorrectText);

        changeColour(pressedButtonIndex);
        revertPressedButtonColor();
    }

    public void setIncorrectText(string text)
    {
        incorrectText.text = text;
        incorrectButton.SetActive(true);
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
        }
        if (isIncorrect && Input.GetMouseButtonDown(0))
        {
            incorrectButton.SetActive(false);
            pressedButtonIndex = -1;
        }
    }

    private void Start()
    {
        generateQuestion();
        enemies.SetActive(false);
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswersData1>().isCorrect = false;
            options[i].GetComponent<AnswersData1>().index = i;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = questions[
                currentQuestionIndex
            ].Answers[i];
            if (questions[currentQuestionIndex].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswersData1>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        if (questions.Count > 0)
        {
            currentQuestionIndex = 0;
            QuestionText.text = questions[currentQuestionIndex].Question;
            SetAnswers();
        }
        else
        {
            interviewCanvas.SetActive(false);
            player.GetComponent<PlayerMovement>().enabled = true;
            Destroy(interviewTrigger);
            enemies.SetActive(true);
        }
    }
}
