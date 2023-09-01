using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Class <c>ClimbController</c> handles the ladder climbing. All objects possessing this
/// component are able to climb the ladder.
/// </summary>
public class ClimbController : MonoBehaviour
{
    public static ClimbController controller;

    private Rigidbody2D rb;

    private bool isTouchingLadder;
    private bool isClimbingLadder;

    private float moveVertical;
    [SerializeField]
    private float climbSpeed = 4f;

    private void Awake()
    {
        controller = this;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveVertical = Input.GetAxisRaw("Vertical");

        IsClimbing();
    }

    private void FixedUpdate()
    {
        Climb();
    }

    /// <summary>
    /// Check if the object climbs the ladder.
    /// </summary>
    private void IsClimbing()
    {
        if (isTouchingLadder && Mathf.Abs(moveVertical) > 0f)
        {
            isClimbingLadder = true;
        }
    }

    /// <summary>
    /// Climb the ladder with the respective speed.
    /// </summary>
    private void Climb()
    {
        if (isClimbingLadder)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, moveVertical * climbSpeed);
        }
        else
        {
            rb.gravityScale = 2f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isTouchingLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isTouchingLadder = false;
            isClimbingLadder = false;
        }
    }
}
