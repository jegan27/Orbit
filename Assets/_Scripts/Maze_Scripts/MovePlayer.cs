using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour
{

    public float speed;

    private Rigidbody rb;

	public InputHandler handler;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
		handler = GetComponent<InputHandler> ();
    }

	public void Update()
	{
		if (handler.usingBoard) 
		{
			if (handler.JoystickX > 128) {
				Vector3 movement = new Vector3 (5, 0, 0);
				rb.AddForce (movement * speed);
			} else if (handler.JoystickY < 128) {
				Vector3 movement = new Vector3 (-5, 0, 0);
				rb.AddForce (movement * speed);
			}

			if (handler.JoystickY > 128) {
				Vector3 movement = new Vector3 (0, 0, 5);
				rb.AddForce (movement * speed);
			} else if (handler.JoystickY < 128) {
				Vector3 movement = new Vector3 (0, 0, -5);
				rb.AddForce (movement * speed);
			}
		}
	}

	public void Hmovement(float Hamount)
	{
		Vector3 movement = new Vector3 (Hamount, 0, 0);
		rb.AddForce(movement * speed);
	}
	public void Vmovement(float Vamount)
	{
		Vector3 movement = new Vector3 (0, 0, Vamount);
		rb.AddForce(movement * speed);
	}
}
