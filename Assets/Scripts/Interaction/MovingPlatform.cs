using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject platform;
    public GameObject targetPos;

    //Private Variable
    private bool isPressed;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPressed = true;
            if (isPressed == true)
            {
                StartCoroutine(platformMove());
            }
        }
    }
    IEnumerator platformMove()
    {
        Vector2 platformPos = platform.transform.position;
        Vector2 targetPosition = targetPos.transform.position;
        while (Vector2.Distance(platformPos, targetPosition) > 0.1f)
        {
            platformPos = Vector2.Lerp(platformPos, targetPosition, 1 * Time.deltaTime);
            platform.transform.position = platformPos;
            yield return null;
        }
    }
}
