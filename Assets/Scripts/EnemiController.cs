using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiController : MonoBehaviour
{
    public float enemySpeed = 1.0f;

    private Animator enemyAnimator;
    private Rigidbody2D enemyRigidbody;

    private bool isMoving;

    public float timeBetweenSteps;
    private float timeBetweenStepsCounter;

    public float timeToMakeStep;
    private float timeToMakeStepCounter;

    public Vector2 directionToMakeStep;

    private const string vertical = "Vertical";
    private const string horizontal = "Horizontal";
    private const string lastHorizontal = "LastHorizontal";
    private const string lastVertical = "LastVertical";
    private const string walkingState = "Walking";

    // Start is called before the first frame update
    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        enemyAnimator = GetComponent<Animator>();

        timeBetweenStepsCounter = timeBetweenSteps;
        timeToMakeStepCounter = timeToMakeStep;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        isMoving = false;
        if (Mathf.Abs(enemyRigidbody.velocity.x) > 0.5f)
        {
            isMoving = true;
            enemyAnimator.SetFloat(horizontal, enemyRigidbody.velocity.x);
            directionToMakeStep = enemyRigidbody.velocity;
        }
        if (Mathf.Abs(enemyRigidbody.velocity.y) > 0.5f)
        {
            isMoving = true;
            enemyAnimator.SetFloat(vertical, enemyRigidbody.velocity.y);
            directionToMakeStep = enemyRigidbody.velocity;
        }

        enemyAnimator.SetBool(walkingState, isMoving);
        enemyAnimator.SetFloat(lastHorizontal, directionToMakeStep.x);
        enemyAnimator.SetFloat(lastVertical, directionToMakeStep.y);
        */

        if (isMoving)
        {
            timeToMakeStepCounter -= Time.deltaTime;
            enemyRigidbody.velocity = directionToMakeStep;
            if (timeToMakeStepCounter < 0)
            {
                isMoving = false;
                timeBetweenStepsCounter = timeBetweenSteps;
                enemyRigidbody.velocity = Vector2.zero;
            }
        }
        else
        {
            timeBetweenStepsCounter -= Time.deltaTime;
            if (timeBetweenStepsCounter < 0)
            {
                isMoving = true;
                timeToMakeStepCounter = timeToMakeStep;
                directionToMakeStep = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2)) * enemySpeed;
                enemyAnimator.SetFloat(lastHorizontal, directionToMakeStep.x);
                enemyAnimator.SetFloat(lastVertical, directionToMakeStep.y);    
            }
        }
        enemyAnimator.SetFloat(horizontal, directionToMakeStep.x);
        enemyAnimator.SetFloat(vertical, directionToMakeStep.y);
        enemyAnimator.SetBool(walkingState, isMoving);
    }
}
