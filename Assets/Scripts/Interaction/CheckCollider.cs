using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckCollider : MonoBehaviour
{
    public GameObject Object;
    private ColliderManager colliderManager;
    private void Start()
    {
        GameObject LoaderObject = GameObject.Find("CheckEvent");
        colliderManager = LoaderObject.GetComponent<ColliderManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Object)
        {
            colliderManager.checkCollider += 1;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == Object)
        {
            colliderManager.checkCollider -= 1;
        }
    }
}
