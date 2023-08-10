using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneManager : MonoBehaviour
{
    public GameObject[] stones;
    public Animator animator;

    private GameObject[] inOder;
    private List<GameObject> inOrder = new List<GameObject>();
    private int currenIndex;


    private Color originalColor = Color.white;
    private void Start()
    {
        inOder = new GameObject[4]; // Create a new array with size 4
        inOder[0] = stones[2]; // Object 3 (index 2) in the correct order
        inOder[1] = stones[0]; // Object 1 (index 0) in the correct order
        inOder[2] = stones[1]; // Object 2 (index 1) in the correct order
        inOder[3] = stones[3]; // Object 4 (index 3) in the correct order
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (currenIndex < inOder.Length && Input.GetKeyDown(KeyCode.E))
        {
            currenIndex++;
            if (CheckStone(collision.gameObject))
            {
                inOrder.Add(collision.gameObject);
                if (currenIndex == 4 && !IsGuessCorrect())
                {
                    ResetPuzzle();
                    StartCoroutine(ColorAnimation());
                }
            }       
        }
        if (currenIndex == 4 && IsGuessCorrect())
        {
            animator.SetTrigger("Play");
        }
    }
    private bool IsGuessCorrect()
    {
        for (int i = 0; i < inOrder.Count; i++)
        {
            if (inOrder[i] != inOder[i])
            {
                return false; // Incorrect guess
            }
        }

        return true; // All guesses are correct
    }
    private bool CheckStone(GameObject stone)
    {
        BoxCollider2D collider = stone.GetComponent<BoxCollider2D>();
        SpriteRenderer renderer = stone.GetComponent<SpriteRenderer>();
        if (collider != null && renderer != null)
        {
            collider.enabled = false;
            originalColor = renderer.color;
            renderer.color = Color.red;
            return true;
        }
        return false;
    }
    private void ResetPuzzle()
    {
        foreach (GameObject stone in stones)
        {
            BoxCollider2D collider = stone.GetComponent<BoxCollider2D>();
            
            if (collider != null)
            {
                collider.enabled = true;
            }
        }
        inOrder.Clear();
        currenIndex = 0;
    }
    private IEnumerator ColorAnimation()
    {
        yield return new WaitForSeconds(0.5f);     
        foreach (GameObject stone1 in stones)
        {
            SpriteRenderer renderer = stone1.GetComponent<SpriteRenderer>();
            if (renderer != null)
            {
                renderer.color = originalColor;
            }
        }
        yield return null;
    }
}