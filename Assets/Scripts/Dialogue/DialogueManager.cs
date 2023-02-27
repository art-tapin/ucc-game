using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Animator animator;
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    private Queue<string> sentences;
    public static bool isActive = false;
    
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }
    
    public void StartDialogue(Dialogue dialogue)
    {
        //GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().enabled = false;
        isActive = true;
        animator.SetBool("IsOpen", true);
        Debug.Log("here");
        nameText.text = dialogue.name;
        
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
              sentences.Enqueue(sentence);

        }
        DisplayNextSentence();
    }
        
    public void DisplayNextSentence()
    {
        Debug.Log(sentences.Count);
        if (sentences.Count ==   0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(typeSentence(sentence));
        //dialogueText.text = sentence;
    }
    
    IEnumerator typeSentence(string sentence)
    {
        dialogueText.text = "";
            foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            System.Threading.Thread.Sleep(10);
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        Debug.Log("ended convo");
        isActive = false;
        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
        
    }    
} 