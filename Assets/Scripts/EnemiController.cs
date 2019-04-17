using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiController : MonoBehaviour
{
    public float speed = 150.0f;

    private const string vertical = "Vertical";
    private const string horizontal = "Horizontal";
    private const string lastHorizontal = "LastHorizontal";
    private const string lastVertical = "LastVertical";
    private const string walkingState = "Walking";

    private Animator animator;
    private Rigidbody2D enemyRigidbody2d;

    private bool walking = false;
    private Vector2 lastMoviment= Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        enemyRigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        walking = false;
        if (Mathf.Abs(enemyRigidbody2d.velocity.x) > 0.5f)
        {
            walking = true;
            animator.SetFloat(horizontal, enemyRigidbody2d.velocity.x);
            lastMoviment = enemyRigidbody2d.velocity;
        }
        if (Mathf.Abs(enemyRigidbody2d.velocity.y) > 0.5f)
        {
            walking = true;
            animator.SetFloat(vertical, enemyRigidbody2d.velocity.y);
            lastMoviment = enemyRigidbody2d.velocity;
        }

        animator.SetBool(walkingState, walking);
        animator.SetFloat(lastHorizontal, lastMoviment.x);
        animator.SetFloat(lastVertical, lastMoviment.y);
    }
}
