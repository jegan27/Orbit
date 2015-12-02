using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	public float speed = 5.0f;
	Vector3 currentPos;

	new InputHandler boardManager;
	Vector2 CameraMovementAxes = new Vector2(0,0);

	void Start()
	{
		currentPos = transform.position;
		currentPos.x = (float)Random.Range (-2, 2);
		currentPos.y = (float)Random.Range (-2, 2);
		transform.position = currentPos;


		boardManager = GameObject.FindGameObjectWithTag ("InputHandler").GetComponent<InputHandler> ();

		//transform.position.y = (float)Random.Range (-2, 2);
	}
		void Update()
	{	//camera movement

		if (!boardManager.usingBoard) {
			if (Input.GetKey (KeyCode.RightArrow)) {
				transform.Translate (new Vector3 (speed * Time.deltaTime, 0, 0));
			}
			if (Input.GetKey (KeyCode.LeftArrow)) {
				transform.Translate (new Vector3 (-speed * Time.deltaTime, 0, 0));
			}
			if (Input.GetKey (KeyCode.DownArrow)) {
				transform.Translate (new Vector3 (0, -speed * Time.deltaTime, 0));
			}
			if (Input.GetKey (KeyCode.UpArrow)) {
				transform.Translate (new Vector3 (0, speed * Time.deltaTime, 0));
			}

			if (boardManager.usingBoard) {
				if (boardManager.JoystickX < 110)
				{
					transform.Translate (new Vector3 (-speed * Time.deltaTime, 0, 0));
				}
				if (boardManager.JoystickX > 140)
				{
					transform.Translate (new Vector3 (speed * Time.deltaTime, 0, 0));
				}
				if (boardManager.JoystickY < 110)
				{
					transform.Translate (new Vector3 (0, -speed * Time.deltaTime, 0));
				}
				if (boardManager.JoystickY > 140)
				{
					transform.Translate (new Vector3 (0, speed * Time.deltaTime, 0));
				}
			}
		}
	
		//x axis
		if (transform.position.x <= -1.0f) {
			transform.position = new Vector2 (-1.0f, transform.position.y);
		} else if (transform.position.x >= 1.0f) {
			transform.position = new Vector2 (1.0f, transform.position.y);
		}
	
		// Y axis
		if (transform.position.y <= -1.0f) {
			transform.position = new Vector2 (transform.position.x, -1.0f);
		} else if (transform.position.y >= 1.0f) {
			transform.position = new Vector2 (transform.position.x, 1.0f);
		}

		Vector3 pos = transform.position;
		pos.z = -10;
		transform.position = pos;
	}

	public void SetVerticalAxis(float Value)
	{
		CameraMovementAxes.y = Value;
	}
	public void SetHorizontalAxis(float Value)
	{
		CameraMovementAxes.x = Value;
	}
	public void ButtonReleased()
	{
		CameraMovementAxes.x = 0;
		CameraMovementAxes.y = 0;
	}
}
