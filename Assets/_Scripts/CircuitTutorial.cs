using UnityEngine;
using System.Collections;

public class CircuitTutorial : MonoBehaviour {

//	public string mission = "Mission: To get all the arrows facing the direction of the electric current.";
//	public string highlighted = "";
//	public string correct = "";
//	public string win = "";
//

	public GameObject[] texts;
	int currentIndex = 0;
	GameObject currentObj;

	 void Start()
	{
		currentObj = texts [currentIndex];
	}
	public void Next()
	{
		//Previous ();
		currentIndex ++;
		currentIndex = currentIndex % texts.Length;
		currentObj.SetActive (true);

	}

	public void Play()
	{
		Application.LoadLevel ("Circuit_Level_1");
	}

	public void Back ()
	{
		//Previous ();
		if (currentIndex == 0) 
		{
			currentIndex = texts.Length - 1;
		} 
		else 
		{
			currentIndex--;
		}
		currentObj.SetActive (true);

	}
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
