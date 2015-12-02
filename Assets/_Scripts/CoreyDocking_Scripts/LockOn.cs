using UnityEngine;
using System.Collections;

public class LockOn : MonoBehaviour {
	public Transform Crosshair;
	private float dist;
	public int lives;
	public AudioClip failSound;
	public AudioClip winSound;
	GUIStyle largeFont;
	GUIStyle mediumFont;
	

	new InputHandler boardManager;

	void Start (){
		largeFont = new GUIStyle ();
		mediumFont = new GUIStyle ();

		largeFont.fontSize = 32;
		mediumFont.fontSize = 18;
		largeFont.normal.textColor = Color.red;
		mediumFont.normal.textColor = Color.white;
	
		boardManager = GameObject.FindGameObjectWithTag ("InputHandler").GetComponent<InputHandler> ();
	}

	void Update() {
		//checks distance between 2 vectors player crosshair and crosshair
		if (Crosshair) {
			dist = Vector3.Distance (Crosshair.position, transform.position);
			print ("Distance to Target: " + dist);

			if (!boardManager.usingBoard) {
				//checks if game won on key down - space
				if (Input.GetKeyDown (KeyCode.Space))
					CheckWin ();
			}

			if (boardManager.usingBoard) {
				if (boardManager.Button2) {
					CheckWin ();
				}
			}
		}
	}
	//GUI lives and tutorial
	void OnGUI (){
		GUI.Label (new Rect(1300, 140, 200, 100), "Tries Remaining: " + (int)lives, largeFont);

		GUI.color = Color.white;
		GUI.Label (new Rect(100, 100, 200, 100), "Use Arrow Keys to Move", mediumFont);
		GUI.Label (new Rect (100, 125, 200, 100),"Use 'Space Bar' to Confirm", mediumFont);   
	}
	//check win function
	public void CheckWin (){
		if (dist <= 5.0015f)
		{
			//if win
			GetComponent<AudioSource>().PlayOneShot(winSound);
			Application.LoadLevel("Pass");
		}

		//if lose life or gameover
		else if (dist >= 5.0015f)
		{
			GetComponent<AudioSource>().PlayOneShot(failSound);
			lives -= 1;
			if ((int) lives == 0)
			{
				Application.LoadLevel("Fail");
			}
		}
	}
}
