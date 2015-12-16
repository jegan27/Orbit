using UnityEngine;
using System.Collections;

public class ShapeManager : MonoBehaviour {

	//select the first object in the scene
	public GameObject CurrentCube;
	int currentIndex = 0;
	
	float timer;

	GameObject currentObj;
	InputHandler boardManager;
	
	Material material2;
	Material material3;
	Material material4;
	Material material5;
	
	bool[] Cubes =  new bool[] {false,false,false,false,false,false,false,false};

	// Use this for initialization
	void Start () {
		CurrentCube.GetComponent<CubeHandler> ().Selected = true;
		boardManager = GameObject.FindGameObjectWithTag ("InputHandler").GetComponent <InputHandler>();
	}
	//still need to keep track of current cube in this script so we can call Rotate() on it
	public void OnBack()
	{
		CubeHandler Cube = CurrentCube.GetComponent<CubeHandler> ();
		Cube.Selected = false;
		CurrentCube = Cube.PrevCube;
		CurrentCube.GetComponent<CubeHandler>().Selected = true;

	}
	public void OnNext()
	{
		CubeHandler Cube = CurrentCube.GetComponent<CubeHandler> ();
		Cube.Selected = false;
		CurrentCube = Cube.NextCube;
		CurrentCube.GetComponent<CubeHandler>().Selected = true;
	}
	bool IsInDeadZone = true;
	// Update is called once per frame
	void Update () 	{


		if (boardManager.usingBoard) {
			if (boardManager.GetComponent<InputHandler>().JoystickX < 110)
			{
				if (IsInDeadZone)
				{
					OnBack();
					IsInDeadZone = false;
				}
			}else
			if (boardManager.GetComponent<InputHandler>().JoystickX > 140)
			{
				if (IsInDeadZone)
				{
					OnNext();
					IsInDeadZone = false;
				}
			}
			else
			{
				IsInDeadZone = true;
			}

			if (boardManager.GetComponent<InputHandler>().Button2)
			{
				CurrentCube.GetComponent<CubeHandler>().Rotate();
			}
		}
		WinCheck();
	}
	public void WinCheck ()
	{

		CubeHandler[] CubeHandlers = Object.FindObjectsOfType<CubeHandler> ();
		foreach (CubeHandler Cube in CubeHandlers)
		{
			if (!Cube.Correct)
			{
				return;
			}
		}
		Application.LoadLevel("Pass");
	
	}
	public void OnRotate()
	{
		CurrentCube.GetComponent<CubeHandler> ().Rotate ();
	}
}
