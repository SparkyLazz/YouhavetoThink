using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzles : MonoBehaviour
{

    [Header("Puzzle Settings")]
    public GameObject[] puzzle;
    public GameObject[] buttons;
    public float SmoothTime;
    private bool isLoad;
    // Update is called once per frame
    void Update()
    {
        var currenButton = buttonPuzzle();
        if (currenButton == null) return;

        if(Input.GetKeyDown(KeyCode.E) && !isLoad)
        {
            int[] indexs;
            if (currenButton == buttons[0])
            {
                indexs = new int[] { 1, 7 };
                StartCoroutine(RotatePlatform(indexs, currenButton));
            }
            if (currenButton == buttons[1])
            {
                indexs = new int[] { 3, 4, 5, 9, 10, 11, 0, 2, 8, 6 };
                StartCoroutine(RotatePlatform(indexs, currenButton));
            }
            if (currenButton == buttons[2])
            {
                indexs = new int[] { 0, 2, 8, 6 };
                StartCoroutine(RotatePlatform(indexs, currenButton));
            }
        }
    }
    GameObject buttonPuzzle()
    {
        var playercollider = GetComponentInChildren<BoxCollider2D>();
        foreach(GameObject button in buttons)
        {
            if(button.GetComponent<BoxCollider2D>().bounds.Intersects(playercollider.bounds))
            {
                return button;
            }
        }
        return null;
    }
    IEnumerator RotatePlatform(int[] indexs, GameObject currenObject)
    {
        BoxCollider2D collider = currenObject.GetComponent<BoxCollider2D>();
        foreach (int index in indexs)
        {
            collider.enabled = false;
            isLoad = true;
            
            Transform platformTransform = puzzle[index].transform;
            float startZRotation = platformTransform.rotation.eulerAngles.z;
            float targetZRotation = (startZRotation + 30f) % 360f;
            Quaternion startRotation = platformTransform.rotation;
            Quaternion targetRotation = Quaternion.Euler(platformTransform.rotation.eulerAngles.x, platformTransform.rotation.eulerAngles.y, targetZRotation);

            float elapsedTime = 0f;
            while (elapsedTime < SmoothTime)
            {
                platformTransform.rotation = Quaternion.Lerp(startRotation, targetRotation, elapsedTime / SmoothTime);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            platformTransform.rotation = targetRotation; // Ensure the final rotation is exactly the target rotation           
        }
        collider.enabled = true;
        isLoad = false;
        yield return null;
    }
}
