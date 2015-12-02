using UnityEngine;
using System.Collections;

public class ShapeManager : MonoBehaviour {


	public GameObject[] listOfShapes;

	
	int currentIndex = 0;
	int winNumber = 0;

	bool usingBoard = false;

	float timer;

	new GameObject currentObj;
	new GameObject boardManager;
	
	Material material1;
	Material material2;
	Material material3;
	Material material4;
	Material material5;

	bool Cube0,Cube1,Cube2,Cube3,Cube4,Cube5,Cube6,Cube8 = false;

	// Use this for initialization
	void Start () {
		currentObj = listOfShapes [currentIndex];
		material1 = Resources.Load("material1", typeof(Material)) as Material;
		material2 = Resources.Load("material2", typeof(Material)) as Material;
		material3 = Resources.Load("material3", typeof(Material)) as Material;
		material4 = Resources.Load("material4", typeof(Material)) as Material;
		material5 = Resources.Load("material5", typeof(Material)) as Material;


		boardManager = GameObject.FindGameObjectWithTag ("InputHandler");

	}
	
	// Update is called once per frame
	void Update () 	{

		if (!usingBoard) {
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				PreviousMaterial ();
				Back ();
				DirectionCheck ();
			}
			if (Input.GetKeyDown (KeyCode.RightArrow)) {
				PreviousMaterial ();
				Next ();
				DirectionCheck ();
			}
			if (Input.GetKeyDown (KeyCode.Space)) {

			}
		} 
		if (usingBoard) {
			if (boardManager.GetComponent<InputHandler>().JoystickX < 110)
			{
				PreviousMaterial();
				Back ();
				DirectionCheck();
			}
			if (boardManager.GetComponent<InputHandler>().JoystickX > 140)
			{
				PreviousMaterial();
				Back ();
				DirectionCheck();
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
			Cube3 = true;
		} else if (currentIndex == 5 && currentObj) {
			currentObj.GetComponent<MeshRenderer> ().material = material4;
			Cube5 = true;
		} else if (currentIndex == 6 && currentObj) {
			currentObj.GetComponent<MeshRenderer> ().material = material4;
			Cube6 = true;
		} else if (currentObj) {
			currentObj.GetComponent<MeshRenderer> ().material = material5;
		}
	}

	public void FacingUp ()
	{
		currentObj = listOfShapes [currentIndex];

		if (currentIndex == 1 && currentObj) {
			currentObj.GetComponent<MeshRenderer> ().material = material4;
			Cube1 = true;
		} else if (currentIndex == 2 && currentObj) {
			currentObj.GetComponent<MeshRenderer> ().material = material4;
			Cube2 = true;
		} else if (currentIndex == 7 && currentObj) {
			currentObj.GetComponent<MeshRenderer> ().material = material4;
			Cube8 = true;
		} else if (currentObj) {
			currentObj.GetComponent<MeshRenderer> ().material = material5;

		}
	}
	
	public void FacingDown ()
	{
		currentObj = listOfShapes [currentIndex];

		if (currentIndex == 0 && currentObj) {
			currentObj.GetComponent<MeshRenderer> ().material = material4;
			Cube0 = true;
		} else if (currentIndex == 4 && currentObj) {
			currentObj.GetComponent<MeshRenderer> ().material = material4;
			Cube4 = true;
		} else if (currentObj) {
			currentObj.GetComponent<MeshRenderer> ().material = material5;

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
		if ((Cube0 && Cube1 && Cube2 && Cube3 && Cube4 && Cube5 && Cube6 && Cube8) == true) {

			timer += Time.deltaTime;

			if(timer > 2)
			{
				Application.LoadLevel("Pass");
			}
		}
	}

}

