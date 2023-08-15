using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [Header("StartPos")]
    public Vector3 startpos;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GameOver"))
        {
            gameObject.transform.position = new Vector3(startpos.x, startpos.y, startpos.z);
        }
    }
}
