using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Password : MonoBehaviour
{
    public GameObject canvas;
    public InputField inputField;
    private LevelLoader levelLoader;
    public Text console;
    public string password;
    private void Start()
    {
        GameObject LoaderObject = GameObject.Find("LevelLoader");
        levelLoader = LoaderObject.GetComponent<LevelLoader>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            canvas.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canvas.gameObject.SetActive(false);
        console.text = string.Empty;
    }
    public void OnSubmit()
    {
        if (inputField.text == password)
        {
            levelLoader.StartCoroutine(levelLoader.loadlevel(1));
        }
        else
        {
            console.text = "Wrong password!";
        }
    }
}
