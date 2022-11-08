using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Include the namespace required to use Unity UI and Input System
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour {
	
	// Create public variables for player speed, and for the Text UI game objects
	public float speed = 0;
	public TextMeshProUGUI countText;
	public GameObject winTextObject;
    
    private Rigidbody rb;
	private int count;

        private float movementX;
        private float movementY;

	// bool floorDetected = false;
	// bool isJump = false;
	// public float jumpForce = 5.0f;


	// At the start of the game..
	void Start ()
	{
		// Assign the Rigidbody component to our private rb variable
		rb = GetComponent<Rigidbody>();

		// Set the count to zero 
		count = 0;

		SetCountText ();

                // Set the text property of the Win Text UI to an empty string, making the 'You Win' (game over message) blank
                winTextObject.SetActive(false);
	}

	void FixedUpdate ()
	{
		// Create a Vector3 variable, and assign X and Z to feature the horizontal and vertical float variables above
		Vector3 movement = new Vector3 (movementX, 0.0f, movementY);


		rb.AddForce (movement * speed);

		// jumpForce = 0.0f;
	}

	void OnTriggerEnter(Collider other) 
	{
		// ..and if the GameObject you intersect has the tag 'Pick Up' assigned to it..
		if (other.gameObject.CompareTag ("PickUp"))
		{
			other.gameObject.SetActive (false);

			// Add one to the score variable 'count'
			count = count + 1;

			// Run the 'SetCountText()' function (see below)
			SetCountText ();
		}
	}

        void OnMove(InputValue value)
        {
        	Vector2 v = value.Get<Vector2>();

        	movementX = v.x;
        	movementY = v.y;	

        }

		// void OnJump()
		// {
		// 	Vector3 floor = transform.TransformDirection(Vector3.down);

		// 	if(Physics.Raycast(transform.position, floor, 1.03f))
		// 	{
		// 		floorDetected = true;
		// 		print("Contacto con el suelo");

		// 	}else
		// 	{
		// 		floorDetected = false;
		// 		print("No hay contacto con el suelo");
		// 	}


		// 	isJump = Input.GetButtonDown("Jump");

		// 	if(isJump)
		// 	{
		// 		rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
		// 	}
        // }
		



        void SetCountText()
	{
		countText.text = "Count: " + count.ToString();

		if (count >= 12) 
		{
                    // Set the text value of your 'winText'
                    winTextObject.SetActive(true);
		}
	}
}
