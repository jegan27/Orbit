using UnityEngine;
using System.Collections;

public class rotateBackground : MonoBehaviour {

	// Use this for initialization
	public float speed = 10f;
	
	
	void Update ()
	{
		transform.Rotate(Vector3.back, speed * Time.deltaTime);
	}
}
