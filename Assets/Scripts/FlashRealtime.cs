using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashRealtime : MonoBehaviour
{
    public GameObject player;
    void Update()
    {
         gameObject.transform.position = player.transform.position;
         Vector3 mousePosition = Input.mousePosition;
         mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
         Vector3 direction = mousePosition - gameObject.transform.position;
         float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
         Quaternion rotation = Quaternion.AngleAxis(angle - 180f, Vector3.forward);
         gameObject.transform.rotation = rotation;
            
    }
}
