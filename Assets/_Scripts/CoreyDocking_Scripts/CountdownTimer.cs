using UnityEngine;
using System.Collections;

public class CountdownTimer : MonoBehaviour {

	public float timeRemaining = 30.0f;
	public AudioClip[] countdownSound;
	public AudioClip countdownBeep;

	GUIStyle largeFont;

		// Use this for initialization
		void Start () {

		largeFont = new GUIStyle ();
		largeFont.normal.textColor = Color.white;
		largeFont.fontSize = 32;
	

		StartCoroutine(PlaySoundEvery(1.0f, 30));
	}
	
	IEnumerator PlaySoundEvery(float t, int times){
		for(int i=0;i<times;i++){
			GetComponent<AudioSource>().PlayOneShot(countdownSound [i]);
			yield return new WaitForSeconds(t);
		}
		
		GetComponent<AudioSource>().PlayOneShot(countdownBeep);
	}
		
		void Update () {
				timeRemaining -= Time.deltaTime;
		}

	void OnGUI (){
	if (timeRemaining > 0) {
			GUI.color = Color.white;
			GUI.Label (new Rect (1300, 100, 200, 100), "Time Remaining: " + (int)timeRemaining, largeFont);
		} 
		else {
			GUI.Label (new Rect(1300, 100, 100, 100), "Time's Up", largeFont);
			Application.LoadLevel (1);
		}
	}		
}
