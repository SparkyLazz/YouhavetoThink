using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialougeManager : MonoBehaviour
{
    private Queue<string> sentences;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }
    public void StartDialouge(DialougeSentenes dialouge)
    {
        sentences.Clear();
        foreach (var sent in dialouge.sentence)
        {
            sentences.Enqueue(sent);
        }
        DisplayNextSentece();
    }
    public void DisplayNextSentece()
    {
        if(sentences.Count == 0)
        {
            EndDialouge();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    IEnumerator TypeSentence(string sentence)
    {
        text.text = "";
        foreach (var item in sentence.ToCharArray())
        {
            text.text += item;
            yield return null;
        }
    }
    void EndDialouge()
    {
        Debug.Log("End");
    }
}
