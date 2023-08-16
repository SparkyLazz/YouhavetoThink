using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class GameOver : MonoBehaviour
{
    [Header("StartPos")]
    public Vector3 startpos;

    [Header("StartEvent")]
    public TextMeshProUGUI Text;
    public float timer;
    private float time;
    private bool start;

    private void Update()
    {     
        if(start)
        {
            Text.text = time.ToString("0");
            time -= 1 * Time.deltaTime;
            if (time <= 0)
            {
                Endgame();
            }
        }
        else
        {
            time = timer;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "EndGame")
        {
            Endgame();
        }
        if (collision.gameObject.name == "StartGame")
        {
            start = true;
            Text.gameObject.SetActive(true);
        }
    }
    void Endgame()
    {
        gameObject.transform.position = new Vector3(startpos.x, startpos.y, startpos.z);
        start = false;
        Text.gameObject.SetActive(false);
    }
}
