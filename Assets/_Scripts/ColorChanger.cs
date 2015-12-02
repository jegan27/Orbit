using UnityEngine;
using System.Collections;

public class ColorChanger : MonoBehaviour {

	float FrameTimer = 0f;
	Color curColor;
	Color nextColor;

	public Color firstColor { get; private set; }
	public Color secondColor { get; private set; }
	public Color thirdColor { get; private set; }

	public Controls controls;
	

	// Use this for initialization

	void Awake()
	{
		firstColor = new Color(Random.value, Random.value, Random.value);
		secondColor = new Color(Random.value, Random.value, Random.value);
		thirdColor = new Color(Random.value, Random.value, Random.value);

		curColor = firstColor;
		nextColor = secondColor;
	}
	
	
	void Start () {
		GetComponent<Renderer>().material.color = curColor;
	}
	
	// Update is called once per frame
	void Update () {
		if (controls.gameState == GameState.PLAYING)
		{
		//
		}
	}

	public void getNextColor ()
	{
		curColor = nextColor;
		if (curColor == firstColor)
		{
			nextColor = secondColor;
		}
		else if (curColor == secondColor)
		{
			nextColor = thirdColor;
		}
		else if (curColor == thirdColor)
		{
			nextColor = firstColor;
		}

		GetComponent<Renderer>().material.color = curColor;
	}

}
