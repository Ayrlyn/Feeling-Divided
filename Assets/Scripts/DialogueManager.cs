using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    Queue<string> sentences;

	// Use this for initialization
	void Start () {
        sentences = new Queue<string>();
	}

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("isOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach(string s in dialogue.sentences)
        {
            sentences.Enqueue(s);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    public void EndDialogue()
    {
        Debug.Log("End of conversation");

        animator.SetBool("isOpen", false);

        switch (nameText.text)
        {
            case "Perrito":
                Destroy(GameObject.Find("Cloner"));
                break;
            case "Foca":
                Destroy(GameObject.Find("Jumper"));
                break;
            case "Gatita":
                Destroy(GameObject.Find("GatitoF"));
                break;
            case "Osito":
                Destroy(GameObject.Find("OsitoF"));
                break;
            default:
                break;
        }
        GameObject.Find("Primary").GetComponent<PlayerAbilities>().talking = false;
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char c in sentence.ToCharArray())
        {
            dialogueText.text += c;
            yield return null;
        }
    }
}
