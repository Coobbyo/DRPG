using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public Rigidbody theRB;
	public float moveSpeed;
	public float jumpForce;

	private Vector2 moveInput;

	public LayerMask ground;
	public Transform groundPoint;
	private bool isGrounded;

	public SpriteRenderer theSR;

	private bool movingBackwards;

	private void Start()
	{

	}

	private void Update()
	{
		moveInput.x = Input.GetAxis("Horizontal");
		moveInput.y = Input.GetAxis("Vertical");
		moveInput.Normalize();

		theRB.velocity = new Vector3(moveInput.x * moveSpeed, theRB.velocity.y, moveInput.y * moveSpeed);

		RaycastHit hit;
		if(Physics.Raycast(groundPoint.position, Vector3.down, out hit, .3f, ground))
		{
			isGrounded = true;
		}
		else
		{
			isGrounded = false;
		}

		if(Input.GetButtonDown("Jump") && isGrounded)
		{
			theRB.velocity += new Vector3(0f, jumpForce, 0f);
		}

		if(!theSR.flipX && moveInput.x < 0)
		{
			theSR.flipX = true;
		}
		else if(theSR.flipX && moveInput.x > 0)
		{
			theSR.flipX = false;
		}

		if(!movingBackwards && moveInput.y > 0)
		{
			movingBackwards = true;
		}
		else if(movingBackwards && moveInput.y < 0)
		{
			movingBackwards = false;
		}
	}
}
