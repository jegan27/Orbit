using UnityEngine;
using System.Collections;

public class RandomCameraMovement : MonoBehaviour {

	public Transform cameraTransform;
	public float shakeLength = 2;
	public float shakeTimer;

	//how hard the camera shakes
	public float shakeAmount = 1.0f;
	public float shakeSpeed = 1.0f;

	public bool isShaking = false;
	public bool shakeOnce = false;
	Vector3 originalPos;
	
	void Awake()
	{
		shakeTimer = shakeLength;
	}
	
	void OnEnable()
	{
		originalPos = cameraTransform.localPosition;
	}
	
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Return) && !isShaking) {
			shakeOnce = true;
			shakeTimer = shakeLength;
		}
		
		if (shakeOnce) {
			Shake ();
		}
	}
	
	public void Shake() {
		if (shakeTimer > 0)
		{
			isShaking = true;
			cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, originalPos + Random.insideUnitSphere * shakeAmount, shakeSpeed);

			shakeTimer -= Time.deltaTime;
		}
		else 
		{
			shakeTimer = 0f;
			cameraTransform.localPosition = originalPos;
			isShaking = false;
			shakeOnce = false;
		}

		Vector3 pos = transform.position;
		pos.z = -12;
		transform.position = pos;
	}
}
