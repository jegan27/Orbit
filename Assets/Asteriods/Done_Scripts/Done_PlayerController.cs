using UnityEngine;
using System.Collections;

[System.Serializable]
public class Done_Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class Done_PlayerController : MonoBehaviour
{
	public float speed;
	
	public Done_Boundary boundary;
	float moveHorizontal = 0;
	float moveVertical = 0;
	
	
	
	private float nextFire;

	
	void Update ()
	{
		
	}

	public void MoveLeft()
	{
		moveHorizontal += -1F;
	}
	public void MoveRight()
	{
		moveHorizontal += 1F;
	}
	public void ButtonReleased()
	{
		moveHorizontal = 0;
	}
	void FixedUpdate ()
	{
		if (GameObject.FindGameObjectWithTag("InputManager").GetComponent<InputHandler>().UsingBoard)
		{
			moveHorizontal = Mathf.Lerp (-1, 1, GameObject.FindGameObjectWithTag("InputManager").GetComponent<InputHandler>().JoystickX / 255);
			//moveVertical = Mathf.Lerp (-1, 1, GameObject.FindGameObjectWithTag("InputManager").GetComponent<InputHandler>().JoystickY / 255);
			
		}

		
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody>().velocity = movement * speed;
		
		
		
		
		GetComponent<Rigidbody>().position = new Vector3
			(
				Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
				0.0f, 
				Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
				);
		

	}
}