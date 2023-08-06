using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Flashlight : MonoBehaviour
{
    public GameObject Player;
    private bool isPickedUp;
    // Update is called once per frame
    void Update()
    {
        SenterRotate();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E) && isPickedUp == false)
            {
                BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();
                isPickedUp = true;
                gameObject.transform.rotation = Player.transform.rotation;
                Destroy(boxCollider2D);              
            }
        }
    }
    void SenterRotate()
    {
        if (isPickedUp == true)
        {
            gameObject.transform.position = Player.transform.position;
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector3 direction = mousePosition - gameObject.transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle - 180f, Vector3.forward);
            gameObject.transform.rotation = rotation;
        }
    }
}
