using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 150.0f;
    //private float currentSpeed;

    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";
    private const string lastHorizontal = "LastHorizontal";
    private const string lastVertical = "LastVertical";
    private const string walkingState = "Walking";
    private const string attackingState = "Attacking";

    private Rigidbody2D playerRigitbody;
    private Animator animator;

    private bool walking = false;
    public Vector2 lastMovement = Vector2.zero;
    public string nextPlaceName;

    private bool attacking = false;
    public float attackTime;
    private float attackTimeCounter;

    public bool playerTalking;

    //player esta creado
    public static bool playerCreated;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerRigitbody = GetComponent<Rigidbody2D>();

        if (!playerCreated)
        {
            playerCreated = true;
            DontDestroyOnLoad(this.transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        playerTalking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTalking)
        {
            playerRigitbody.velocity = Vector2.zero;
            return;
        }
        walking = false;

        if (Input.GetMouseButtonDown(0))
        {
            attacking = true;
            attackTimeCounter = attackTime;
            playerRigitbody.velocity = Vector2.zero;
            animator.SetBool(attackingState, attacking);
        }

        if (attacking)
        {
            attackTimeCounter -= Time.deltaTime;
            if (attackTimeCounter < 0)
            {
                attacking = false;
                animator.SetBool(attackingState, attacking);
            }
        }
        else
        {
            /*
            if (Mathf.Abs(Input.GetAxisRaw(horizontal)) > 0.5f)
            {
                //this.transform.Translate(new Vector3(Input.GetAxisRaw(horizontal) * speed * Time.deltaTime, 0, 0));
                playerRigitbody.velocity = new Vector2(Input.GetAxisRaw(horizontal) * currentSpeed * Time.deltaTime, playerRigitbody.velocity.y);
                walking = true;
                lastMovement = new Vector2(Input.GetAxisRaw(horizontal), 0);
            }
            if (Mathf.Abs(Input.GetAxisRaw(vertical)) > 0.5f)
            {
                //this.transform.Translate(new Vector3(0, Input.GetAxisRaw(vertical) * speed * Time.deltaTime, 0));
                playerRigitbody.velocity = new Vector2(playerRigitbody.velocity.x, Input.GetAxisRaw(vertical) * currentSpeed * Time.deltaTime);
                walking = true;
                lastMovement = new Vector2(0, Input.GetAxisRaw(vertical));
            }
            currentSpeed = Mathf.Abs(Input.GetAxisRaw(horizontal)) > 0.5f && Mathf.Abs(Input.GetAxisRaw(vertical)) > 0.5f ? speed / Mathf.Sqrt(2) : speed;
            */
            if (Mathf.Abs(Input.GetAxisRaw(horizontal)) > 0.5f || Mathf.Abs(Input.GetAxisRaw(vertical)) > 0.5f) {
                walking = true;
                lastMovement = new Vector2(Input.GetAxisRaw(horizontal), Input.GetAxisRaw(vertical));
                playerRigitbody.velocity = lastMovement.normalized * speed * Time.deltaTime;
            }
        }
        if (!walking)
        {
            playerRigitbody.velocity = Vector2.zero;
        }

        animator.SetFloat(horizontal, Input.GetAxisRaw(horizontal));
        animator.SetFloat(vertical, Input.GetAxisRaw(vertical));
        animator.SetBool(walkingState, walking);
        animator.SetFloat(lastHorizontal, lastMovement.x);
        animator.SetFloat(lastVertical, lastMovement.y);
    }
}
