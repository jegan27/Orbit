using UnityEngine;
using System.Collections;

public class OnTriggerLose : MonoBehaviour {

	void OnTriggerExit(Collider other) {
		// Destroy everything that leaves the trigger
		Destroy(other.gameObject);
		Application.LoadLevel("Fail");
	}
}