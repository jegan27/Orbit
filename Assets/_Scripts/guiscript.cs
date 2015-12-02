using UnityEngine;
using System.Collections;

public class guiscript : MonoBehaviour {

	string IncFreq = "Increase Frequency";
	string DecFreq = "Decrease Frequency";
	string IncSpeed = "Increase Speed";
	string DecSpeed = "Decrease Speed";

	PlayerCurve pcurvescript;

	void Start()
	{
		pcurvescript = GameObject.FindGameObjectWithTag ("pcurve").GetComponent<PlayerCurve> ();
	}

	void OnGUI()
	{
		if (GUI.Button (new Rect (Screen.width / 2 - 730, Screen.height / 2 + 290, 200, 60), IncFreq)) 
		{
			pcurvescript.changeFrequency(0.1f);
		}
		if (GUI.Button (new Rect (Screen.width / 2 - 730, Screen.height / 2 + 410, 200, 60), DecFreq)) 
		{
			pcurvescript.changeFrequency(-0.1f);
		}
		if (GUI.Button (new Rect (Screen.width / 2 + 510, Screen.height / 2 + 290, 200, 60), IncSpeed)) {
			pcurvescript.changeSpeed(0.1f);
		}
		if (GUI.Button (new Rect (Screen.width / 2 + 510, Screen.height / 2 + 410, 200, 60), DecSpeed)) {
			pcurvescript.changeSpeed(-0.1f);
		}
	}

}
