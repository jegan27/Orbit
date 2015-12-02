using UnityEngine;
using System.Collections;

public class RotateScript : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			gameObject.transform.Rotate(0,90, 0);
		}

	}	
}
