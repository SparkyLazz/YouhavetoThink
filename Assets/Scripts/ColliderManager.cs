using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderManager : MonoBehaviour
{
    public int checkCollider;
    public Animator animator;
    public Animator finishAnim;
    [Header("Transform")]
    public GameObject object_1;
    public GameObject object_2;
    private Rigidbody2D rb_1;
    private Rigidbody2D rb_2;

    private void Start()
    {
        rb_1 = object_1.GetComponent<Rigidbody2D>();
        rb_2 = object_2.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (checkCollider == 2)
        {
            StartCoroutine(playCheck());  
        }
    }
    IEnumerator playCheck()
    {
        yield return new WaitForSeconds(2);
        finishAnim.SetTrigger("Finish");
        yield return new WaitForSeconds(1);
        animator.SetTrigger("Play");
        yield return new WaitForSeconds(1);
        rb_1.constraints = RigidbodyConstraints2D.FreezePositionX;
        rb_2.constraints = RigidbodyConstraints2D.FreezePositionX;
        yield return null;
    }
}
