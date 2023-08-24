using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzles : MonoBehaviour
{

    [Header("Puzzle Settings")]
    public GameObject[] puzzle;
    public GameObject[] buttons;
    public Animator animator;
    public float SmoothTime;
    private bool isLoad;
    private int topPlatformRotated;
    private int rightPlatformRotated;
    private bool teleported = false;
    // Update is called once per frame
    private void Start()
    {

    }
    void Update()
    {       
        if (isLoad == false)
        {
            if (isDone())
            {
                foreach (var button in buttons)
                {
                    BoxCollider2D collider = button.GetComponent<BoxCollider2D>();
                    collider.enabled = false;
                }
                animator.SetTrigger("End");
                if(!teleported)
                {
                    StartCoroutine(teleportPlayer());
                    teleported = true;
                }
            }
        }
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

    IEnumerator teleportPlayer()
    {
        yield return new WaitForSeconds(9);
        animator.SetTrigger("Teleported");
        yield return new WaitForSeconds(0.5f);
        gameObject.transform.position = new Vector3(-9.38f, 21.95f, 0.06822363f);
        Camera.main.transform.position = new Vector2(-0.11f, 26.56f);
        Camera.main.orthographicSize = 6.11f;
        yield return null;
    }
    bool isDone()
    {
        foreach (GameObject platform in puzzle)
        {
            float zRotation = platform.transform.rotation.eulerAngles.z;
            // Normalize platform name to remove spaces and ensure lowercase
            string normalizedPlatformName = platform.name.ToLower().Replace(" ", "");                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           
            if (normalizedPlatformName == "top&bottom")
            {
                if (Mathf.Approximately(zRotation % 180, 0) || Mathf.Approximately(zRotation % 180, 180))
                {
                    if(topPlatformRotated < 6)
                    {
                        topPlatformRotated++;
                    }
                }
                else
                {
                    topPlatformRotated = 0;
                }
            }

            if (normalizedPlatformName == "left&right")
            {
                if (Mathf.Approximately(zRotation % 180, 90) || Mathf.Approximately(zRotation % 180, -90))
                {
                    if (rightPlatformRotated < 6)
                    {
                        rightPlatformRotated++;
                    }
                }
                else
                {
                    rightPlatformRotated = 0;
                }
            }
        }
        // Return true only if all required platforms are in correct rotations
        return topPlatformRotated == 6 && rightPlatformRotated == 6;
    }
}
