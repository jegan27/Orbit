using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

	public Transform camTransform;
	
	// How long the object should shake for.
	public float shake = 0f;
	
	// Amplitude of the shake. A larger value shakes the camera harder.
	public float shakeAmount = 0.5f;
	public float decreaseFactor = 1.0f;
	
	Vector3 originalPos;
	
	void Awake()
	{
		if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
	}
	
	void OnEnable()
	{
		originalPos = camTransform.localPosition;
	}
	
	void Update()
	{
		if (shake > 0)
		{

			//camTransform.localPosition = originalPos + (Vector3)Random.insideUnitCircle * shakeAmount;
			//Debug.Log (camTransform.localPosition);
			camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
			//camTransform.localPosition.z = 0;
			/*Vector3 pos = transform.position;
			pos.z = 0;
			transform.position = pos;*/

			shake -= Time.deltaTime * decreaseFactor;
		}
		else
		{
			shake = 0f;
			camTransform.localPosition = originalPos;
		}
	}
}
