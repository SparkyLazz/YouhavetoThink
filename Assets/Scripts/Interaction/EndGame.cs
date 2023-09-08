using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    private LevelLoader levelLoader;
    public bool isCredit;
    // Start is called before the first frame update
    void Start()
    {
        GetLoaderScript();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            levelLoader.StartCoroutine(levelLoader.loadlevel(1));
        }
        if(isCredit)
        {
            if(collision.gameObject.CompareTag("Player"))
            {
                levelLoader.StartCoroutine(levelLoader.loadlevel(10));
            }
        }

    }
    void GetLoaderScript()
    {
        GameObject LoaderObject = GameObject.Find("LevelLoader");
        levelLoader = LoaderObject.GetComponent<LevelLoader>();
    }
}
