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
        if (gameObject.CompareTag("Interactable"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                TriggerDialouge();
            }
        }
    }
}
