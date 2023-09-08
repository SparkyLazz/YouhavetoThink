using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GuildeManager : MonoBehaviour
{
    public Animator DialougeAnimation;
    public Animator GuildeTransition;
    public TextMeshProUGUI GuildeText;
    public string Sentences;
    // Update is called once per frame
    private void Start()
    {
        GuildeText.text = Sentences;
    }
    void Update()
    {
        if (DialougeAnimation.GetCurrentAnimatorStateInfo(0).IsName("Dialouge_End"))
        {
            StartCoroutine(PlayTransition());
        }
    }
    IEnumerator PlayTransition()
    {
        //Dia hanya bekerja sampai program selesai
        yield return new WaitForSeconds(3);
        GuildeTransition.SetTrigger("Play");
        yield return new WaitForSeconds(6);
        GuildeTransition.SetTrigger("End");
        yield return null;
    }
}
