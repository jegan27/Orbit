using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class audioTimer : MonoBehaviour {

	public float timeLeft = 25;

	public Text counterText;



	// Use this for initialization
	void Start () {
		counterText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {

		timeLeft -= Time.deltaTime;
		counterText.text = timeLeft.ToString("f0"); 
		print (timeLeft);
		if(timeLeft < 0)
		{
			Application.LoadLevel("Fail");
		}
	}
}
