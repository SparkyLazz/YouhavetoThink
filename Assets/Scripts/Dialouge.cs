using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Diagnostics;

public class Dialouge : MonoBehaviour
{
    [Header("Animation Controller")]
    public TextMeshProUGUI text;
    public Animator transtiiton;
    public PlayerMovement playermovement;

    //Get Data from database
    private DialougeData dialougeData;
    private string[] specificArray;

    
    //Private variable
    private float delayBetweenSection = 4f;
    private int currenIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        dialougeData = new DialougeData();
        DialougeManager();
        StartCoroutine(DisplayStory());
    }
    IEnumerator DisplayStory()
    {
        while (currenIndex < specificArray.Length)
        {
            text.text = specificArray[currenIndex];
            yield return new WaitForSeconds(delayBetweenSection);
            currenIndex++;
            GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
        }
        transtiiton.SetTrigger("End");
        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
        yield return null;
    }
    void DialougeManager()
    {
        string currentScneName = SceneManager.GetActiveScene().name;
        switch (currentScneName)
        {
            case "Level 1":
                specificArray = dialougeData.Dialouge_level1;
                break;
            case "Level 2":
                specificArray = dialougeData.Dialouge_level2;
                break;
            case "Level 3":
                specificArray = dialougeData.Dialouge_level3;
                break;
            case "Level 4":
                specificArray = dialougeData.Dialouge_level4;
                break;
            case "Level 5":
                specificArray = dialougeData.Dialouge_level5;
                break;
            case "Level 6":
                specificArray = dialougeData.Dialouge_level6;
                break;

        }
    }

}
