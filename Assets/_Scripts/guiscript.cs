using UnityEngine;
using System.Collections;

public class guiscript : MonoBehaviour {

	string Freq = "Adjusting Fequency";
	string Speed = "Adjusting Speed";
	string guistart = "Hold 'S' and use the Arrow Keys to adjust the Speed\nHold 'F' and use the Arrow Keys to adjust the Frequency";
	

	void OnGUI()
	{

		if (Input.GetKey (KeyCode.F)) 
		{
			GUI.Label(new Rect(Screen.width/2 - 100, Screen.height/2 + 300, 400, 100), Freq);
		} else if (Input.GetKey (KeyCode.S)) 
		{
			GUI.Label(new Rect(Screen.width/2 - 100, Screen.height/2 + 300, 400, 100), Speed);
		} else 
		{
			GUI.Label(new Rect(Screen.width/2 - 150, Screen.height/2 + 300, 400, 100), guistart);
		}
	}

}
