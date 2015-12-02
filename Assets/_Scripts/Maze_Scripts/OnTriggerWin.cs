using UnityEngine;
using System.Collections;

public class OnTriggerWin : MonoBehaviour {

	void OnTriggerExit(Collider other) {
		// Destroy everything that leaves the trigger
		Destroy(other.gameObject);

		Application.LoadLevel("Pass");
	}
}