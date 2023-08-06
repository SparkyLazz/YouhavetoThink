using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Paper : MonoBehaviour
{
    public GameObject panel;
    public TextMeshProUGUI textMeshPro;
    public string Text;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            textMeshPro.text = Text;
            panel.SetActive(true);
        }
    }

}
