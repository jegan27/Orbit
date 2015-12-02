using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	public float speed = 5.0f;
	Vector3 currentPos;


	void Start()
	{
		currentPos = transform.position;
		currentPos.x = (float)Random.Range (-2, 2);
		currentPos.y = (float)Random.Range (-2, 2);
		transform.position = currentPos;


		//transform.position.y = (float)Random.Range (-2, 2);
	}
		void Update()
	{	//camera movement
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
}
