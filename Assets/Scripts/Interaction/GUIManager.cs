using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GUIManager : MonoBehaviour
{
    public TextMeshProUGUI Text;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            Text.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Text.gameObject.SetActive(false);
            }
        }
        else
        {
            return;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            Text.gameObject.SetActive(false);
        }
    }
}
