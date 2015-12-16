using UnityEngine;
using System.Collections;
public enum CubeDirection
{
	CUBE_UP,
	CUBE_RIGHT,
	CUBE_DOWN,
	CUBE_LEFT
};
public class CubeHandler : MonoBehaviour {
	
	int currentIndex = 0;
	CubeDirection CurrentOrientation = CubeDirection.CUBE_UP;
	public CubeDirection DesiredOrientation = CubeDirection.CUBE_UP;
	public bool Selected = false;
	public GameObject PrevCube;
	public GameObject NextCube;
	public bool Correct = false;

	GameObject currentObj;

	Material material2;
	Material material3;
	Material material4;
	Material material5;

	// Use this for initialization
	void Start () {

		currentObj = gameObject;
		
		material2 = Resources.Load ("material2", typeof(Material)) as Material;
		material3 = Resources.Load ("material3", typeof(Material)) as Material;
		material4 = Resources.Load ("material4", typeof(Material)) as Material;
		material5 = Resources.Load ("material5", typeof(Material)) as Material;

		DirectionCheck ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Selected) {

			if (CurrentOrientation == DesiredOrientation) {
				currentObj.GetComponent<MeshRenderer> ().material = material4;
				Correct = true;
			} else {
				currentObj.GetComponent<MeshRenderer> ().material = material5;
				Correct = false;
			}
		}
		else if (CurrentOrientation == DesiredOrientation) {
			currentObj.GetComponent<MeshRenderer> ().material = material3;
			Correct = true;
		} else {
			currentObj.GetComponent<MeshRenderer> ().material = material2;
			Correct = false;
		}
	}

	public void DirectionCheck ()
	{
		if (currentObj.transform.eulerAngles.y == 0) {
			CurrentOrientation = CubeDirection.CUBE_RIGHT;
		} else if (currentObj.transform.eulerAngles.y >=89 && currentObj.transform.eulerAngles.y < 91) {
			CurrentOrientation = CubeDirection.CUBE_DOWN;
		} else if (currentObj.transform.eulerAngles.y == 180) {	
			CurrentOrientation = CubeDirection.CUBE_LEFT;
		} else if (currentObj.transform.eulerAngles.y == 270) {	
			CurrentOrientation = CubeDirection.CUBE_UP;
		}
		//check if we are correct and store the result in Correct;
	}

	public void Rotate()
	{
		currentObj.transform.Rotate (0, 90, 0);
		DirectionCheck ();
	}
}
