using UnityEngine;
using System.Collections;

public class ShapeManager : MonoBehaviour {


	public GameObject[] listOfShapes;
		
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
		currentObj = listOfShapes [currentIndex];

		material2 = Resources.Load("material2", typeof(Material)) as Material;
		material3 = Resources.Load("material3", typeof(Material)) as Material;
		material4 = Resources.Load("material4", typeof(Material)) as Material;
		material5 = Resources.Load("material5", typeof(Material)) as Material;


		boardManager = GameObject.FindGameObjectWithTag ("InputHandler").GetComponent <InputHandler>();


		//button1.visible = (!boardManager.usingBoard)

	}

	public void OnBack()
	{
		PreviousMaterial ();
		Back ();
		DirectionCheck ();
	}
	public void OnNext()
	{
		PreviousMaterial ();
		Next ();
		DirectionCheck ();
	}
	public void OnRotate()
	{
		currentObj.transform.Rotate (0, 90, 0);
		DirectionCheck ();
	}


	bool IsInDeadZone = true;
	// Update is called once per frame
	void Update () 	{


		if (boardManager.usingBoard) {
			if (boardManager.GetComponent<InputHandler>().JoystickX < 110)
			{
				if (IsInDeadZone)
				{
					PreviousMaterial();
					Back ();
					DirectionCheck();
					IsInDeadZone = false;
				}
			}else
			if (boardManager.GetComponent<InputHandler>().JoystickX > 140)
			{
				if (IsInDeadZone)
				{
					PreviousMaterial();
					Back ();
					DirectionCheck();
					IsInDeadZone = false;
				}
			}
			else
			{
				IsInDeadZone = true;
			}

			if (boardManager.GetComponent<InputHandler>().Button2)
			{
				currentObj.transform.Rotate (0, 90, 0);
				DirectionCheck ();
			}
		}


		WinCheck();
	}

	public void Next()
	{
		currentIndex ++;
		currentIndex = currentIndex % listOfShapes.Length;

	}

	public void Back ()
	{
		if (currentIndex == 0) {
			currentIndex = listOfShapes.Length - 1;
		} else 
			{
				currentIndex--;
			}
	}

	public void DirectionCheck ()
	{
		currentObj = listOfShapes [currentIndex];

		if (currentObj.transform.eulerAngles.y == 0) {
			FacingRight ();
		} else if (currentObj.transform.eulerAngles.y > 90 && currentObj.transform.eulerAngles.y < 91) {
			FacingDown ();
		} else if (currentObj.transform.eulerAngles.y == 180) 
		{
			FacingLeft ();
		} else if (currentObj.transform.eulerAngles.y == 270) 
		{
			FacingUp ();
		}
	}

	public void FacingLeft ()
	{
		currentObj = listOfShapes [currentIndex];
		currentObj.GetComponent<MeshRenderer> ().material = material2;
		if (currentObj) {
			currentObj.GetComponent<MeshRenderer> ().material = material5;
		}
	}

	public void FacingRight ()
	{
		currentObj = listOfShapes [currentIndex];

		if (currentIndex == 3 && currentObj) {
			currentObj.GetComponent<MeshRenderer> ().material = material4;
			Cubes[3] = true;
		} else if (currentIndex == 5 && currentObj) {
			currentObj.GetComponent<MeshRenderer> ().material = material4;
			Cubes[5] = true;
		} else if (currentIndex == 6 && currentObj) {
			currentObj.GetComponent<MeshRenderer> ().material = material4;
			Cubes[6] = true;
		} else if (currentObj) {
			currentObj.GetComponent<MeshRenderer> ().material = material5;
		}
	}

	public void FacingUp ()
	{
		currentObj = listOfShapes [currentIndex];

		if (currentIndex == 1 && currentObj) {
			currentObj.GetComponent<MeshRenderer> ().material = material4;
			Cubes[1] = true;
		} else if (currentIndex == 2 && currentObj) {
			currentObj.GetComponent<MeshRenderer> ().material = material4;
			Cubes[2] = true;
		} else if (currentIndex == 7 && currentObj) {
			currentObj.GetComponent<MeshRenderer> ().material = material4;
			Cubes[7] = true;
		} else if (currentObj) {
			currentObj.GetComponent<MeshRenderer> ().material = material5;

		}
	}
	
	public void FacingDown ()
	{
		currentObj = listOfShapes [currentIndex];

		if (currentIndex == 0 && currentObj) {
			currentObj.GetComponent<MeshRenderer> ().material = material4;
			Cubes[0] = true;
		} else if (currentIndex == 4 && currentObj) {
			currentObj.GetComponent<MeshRenderer> ().material = material4;
			Cubes[4] = true;
		} else if (currentObj) {
			currentObj.GetComponent<MeshRenderer> ().material = material5;

			Cubes[currentIndex] = false;

		}
	}

	public void PreviousMaterial ()
	{
		currentObj = listOfShapes [currentIndex];
		if (currentIndex == 0 && currentObj.transform.eulerAngles.y > 90 && currentObj.transform.eulerAngles.y < 91) {
			currentObj.GetComponent<MeshRenderer> ().material = material3;
		} else if (currentIndex == 4 && currentObj.transform.eulerAngles.y > 90 && currentObj.transform.eulerAngles.y < 91) {
			currentObj.GetComponent<MeshRenderer> ().material = material3;
		}  else if (currentIndex == 1 && currentObj.transform.eulerAngles.y == 270) {
			currentObj.GetComponent<MeshRenderer> ().material = material3;
		} else if (currentIndex == 2 && currentObj.transform.eulerAngles.y == 270) {
			currentObj.GetComponent<MeshRenderer> ().material = material3;
		} else if (currentIndex == 7 && currentObj.transform.eulerAngles.y == 270) {
			currentObj.GetComponent<MeshRenderer> ().material = material3;
		} else if (currentIndex == 3 && currentObj.transform.eulerAngles.y == 0) {
			currentObj.GetComponent<MeshRenderer> ().material = material3;
		} else if (currentIndex == 5 && currentObj.transform.eulerAngles.y == 0) {
			currentObj.GetComponent<MeshRenderer> ().material = material3;
		} else if (currentIndex == 6 && currentObj.transform.eulerAngles.y == 0) {
			currentObj.GetComponent<MeshRenderer> ().material = material3;
		} else 
			currentObj.GetComponent<MeshRenderer> ().material = material2;

		}

	public void WinCheck ()
	{
		bool AllCorrect = true;
		foreach (bool Cube in Cubes)
		{
			AllCorrect &= Cube;
		}
		if (AllCorrect){
		
			timer += Time.deltaTime;

			if(timer > 2)
			{
				Application.LoadLevel("Pass");
			}
		}
	}
}
