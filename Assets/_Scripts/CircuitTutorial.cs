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


//	public GameObject[] texts;
//	int currentIndex = 0;
//	GameObject currentObj;
//
//	 void Start()
//	{
//		currentObj = texts [currentIndex];
//	}
//	public void Next()
//	{
//		//Previous ();
//		currentIndex ++;
//		currentIndex = currentIndex % texts.Length;
//		currentObj.SetActive (true);
//
//	}
//
//	public void Play()
//	{
//		Application.LoadLevel ("Circuit_Level_1");
//	}
//
//	public void Back ()
//	{
//		//Previous ();
//		if (currentIndex == 0) 
//		{
//			currentIndex = texts.Length - 1;
//		} 
//		else 
//		{
//			currentIndex--;
//		}
//		currentObj.SetActive (true);
//
//	}
//
////	public void Previous()
////	{
////		if (currentIndex == 0 && !currentObj)
////		{texts[0].gameObject.SetActive(false);}
////		else if (currentIndex == 1 && !currentObj)
////		{texts[1].gameObject.SetActive(false);}
////		else if (currentIndex == 2 && !currentObj)
////		{texts[2].gameObject.SetActive(false);}
////		else if (currentIndex == 3 && !currentObj)
////		{texts[3].gameObject.SetActive(false);}
////	}

}
