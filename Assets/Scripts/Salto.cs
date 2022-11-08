using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto : MonoBehaviour
{

    private Rigidbody rb;

    bool floorDetected = false;
	bool isJump = false;
	public float jumpForce = 5.0f;

void Start ()
	{
		// Assign the Rigidbody component to our private rb variable
		rb = GetComponent<Rigidbody>();

	
	}


   void OnJump()
		{
			Vector3 floor = transform.TransformDirection(Vector3.down);

			if(Physics.Raycast(transform.position, floor, 1.03f))
			{
				floorDetected = true;
			}else
			{
				floorDetected = false;
			}


			isJump = Input.GetButtonDown("Jump");

			if(isJump)
			{
				rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
			}
        }
}
