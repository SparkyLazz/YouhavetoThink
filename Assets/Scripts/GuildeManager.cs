using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuildeManager : MonoBehaviour
{
    public Animator DialougeAnimation;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (DialougeAnimation.GetCurrentAnimatorStateInfo(0).IsName("Dialouge_End"))
        {
            Debug.Log("Animation is finished");
        }
    }
}
