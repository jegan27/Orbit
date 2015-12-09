using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CircuitTutorial : MonoBehaviour {

	public string mission = "Mission: To get all the arrows facing the direction of the electric current.";
	public string highlighted = "The arrow higlighted in blue is your current object.";
	public string correct = "The Arrow will go GREEN if facing the correct direction, RED if it is incorrect.";
	public string win = "Turn all the arrows GREEN within the alloted time to complete the mission.";

	public Text tut_text;

	public int index;

	public void Start()
	{
		tut_text.text = mission;
		index = 0;
	}

	public void Next()
	{
		index ++;
		if (index == 0) {
			tut_text.text = mission;
		}
		if (index == 1) {
			tut_text.text = highlighted;
		}
		if (index == 2) {
			tut_text.text = correct;
		}
		if (index == 3) {
			tut_text.text = win;
			index = -1;
		}

	}

	public void Play()
	{
		Application.LoadLevel ("Circuit_Level_1");
	}
//	public void Back()
//	{
//		index --;
//		if (index == 0) {
//			tut_text.text = mission;
//		}
//		if (index == 1) {
//			tut_text.text = highlighted;
//		}
//		if (index == 2) {
//			tut_text.text = correct;
//		}
//		if (index == 3) {
//			tut_text.text = win;
//		}
//	}
}
