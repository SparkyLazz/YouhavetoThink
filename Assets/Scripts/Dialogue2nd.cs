using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue2nd : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        JensenAnakHaram();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void JensenAnakHaram()
    {
        index = 0;
        StartCoroutine(JensenXViolyn());
    }
    IEnumerator JensenXViolyn()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        yield return null;
    }
}
