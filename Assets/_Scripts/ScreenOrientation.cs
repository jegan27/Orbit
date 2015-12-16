using UnityEngine;
using System.Collections;

public class ScreenOrientation : MonoBehaviour {

	// Use this for initialization
	void Start () {

		Screen.orientation = UnityEngine.ScreenOrientation.Portrait;
	}
	
	public static bool NeedsReload = false;
}
