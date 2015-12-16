using UnityEngine;
using System.Collections;

public class Reload : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (ScreenOrientation.NeedsReload) {

			ScreenOrientation.NeedsReload = false;
			Application.LoadLevel(Application.loadedLevelName);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
