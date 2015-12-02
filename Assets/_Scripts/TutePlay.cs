using UnityEngine;
using System.Collections;

public class TutePlay : MonoBehaviour {
	public float timeRemaining = 7.0f;
	// Use this for initialization
	void Start () {

	}
	void Update () {
		timeRemaining -= Time.deltaTime;
	}
	
	void OnGUI (){
		if (timeRemaining > 0) {
			GUI.Label (new Rect (100, 100, 200, 100), "Time Remaining: " + (int)timeRemaining);
		} 
		else {
			GUI.Label (new Rect(100, 100, 100, 100), "Time's Up");
			Application.LoadLevel ("Docking_Level_1");
		}
	}		
}

