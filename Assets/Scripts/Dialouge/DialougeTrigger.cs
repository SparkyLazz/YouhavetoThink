using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeTrigger : MonoBehaviour
{
    public DialougeSentenes dialouge;
    public void TriggerDialouge()
    {
        FindObjectOfType<DialougeManager>().StartDialouge(dialouge);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                TriggerDialouge();
            }
        }
    }
}
