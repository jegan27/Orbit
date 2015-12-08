using UnityEngine;
using System.Collections;

public class ScreenResolution : MonoBehaviour {

	public Camera mainCamera;

	// Use this for initialization
	void Start () {

		mainCamera.aspect = (Screen.currentResolution.width / Screen.currentResolution.height);

	}
	

}
