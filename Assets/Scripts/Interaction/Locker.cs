using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Locker : MonoBehaviour
{
    public GameObject platform;
    public GameObject targetPos;
    Key key;
    private void Start()
    {
        key = FindAnyObjectByType<Key>();
    }
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            bool keyBool = key.isGetKey;
            if (Input.GetKeyDown(KeyCode.E) && keyBool == true)
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
