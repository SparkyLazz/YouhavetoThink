using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Credit : MonoBehaviour
{
    public Animator DialougeAnimation;
    public Animator GuildeTransition;
    bool isDone;
    bool isFinish;
    // Update is called once per frame
    void Update()
    {
        if (DialougeAnimation.GetCurrentAnimatorStateInfo(0).IsName("Dialouge_End") && isDone == false)
        {
            StartCoroutine(PlayTransition());
            if(isFinish == true && Input.GetMouseButtonDown(0))
            {
                FindAnyObjectByType<LevelLoader>().ToMenu();
                isDone = true;
            }
        }
    }
    IEnumerator PlayTransition()
    {
        //Dia hanya bekerja sampai program selesai
        yield return new WaitForSeconds(5);
        GuildeTransition.SetTrigger("Play");
        yield return new WaitForSeconds(50);
        isFinish = true;
        yield return null;
    }
}