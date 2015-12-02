using UnityEngine;
using System.Collections;

public class LoadProto : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public void Update () {
		if (Input.GetKeyDown (KeyCode.Return))
			Application.LoadLevel ("Docking_Level_2");
	}
}
