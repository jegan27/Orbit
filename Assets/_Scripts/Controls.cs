using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum GameState
{
	ERROR = 0,
	START,
	PLAYING,
	WIN,
	LOSS,
}

public class Controls : MonoBehaviour {

	public ColorPanel firstPanel;
	public ColorPanel secondPanel;
	public ColorPanel thirdPanel;

	ColorPanel curPanel;

	public ColorChanger colChanger;

	public float timeLimit = 15.0f;

	public GameState gameState = GameState.START;

	public Text displayText;

	public Slider colSlider;

	

	// Use this for initialization
	void Start () {

		curPanel = firstPanel;

		curPanel.bSelected = true;
		SetSlider();
	
	}
	
	ColorPanel getNextPanel(ColorPanel panel)
	{
		colChanger.getNextColor();
		if (panel == firstPanel)
		{
			return secondPanel;
		}
		if (panel == secondPanel)
		{
			return thirdPanel;
		}
		if (panel == thirdPanel)
		{
			return firstPanel;
		}

		else return secondPanel;
	}

	ColorPanel getPrevPanel(ColorPanel panel)
	{
		colChanger.getNextColor();
		colChanger.getNextColor();
		if (panel == firstPanel)
		{
			return thirdPanel;
		}
		if (panel == thirdPanel)
		{
			return secondPanel;
		}
		if (panel == secondPanel)
		{
			return firstPanel;
		}

		else return secondPanel;
	}

	public void getNextPanel()
	{
		curPanel.bSelected = false;
		curPanel = getNextPanel(curPanel);
		curPanel.bSelected = true;
		SetSlider();
	}

	public void getPrevPanel()
	{
		curPanel.bSelected = false;
		curPanel = getPrevPanel(curPanel);
		curPanel.bSelected = true;
		SetSlider();
	}

	public void SetSlider()
	{
		colSlider.value = curPanel.getCurHue();
	}

	public void ChangeCurHue(float sliderVal)
	{
		curPanel.ChangeColor(sliderVal);
	}
	// Update is called once per frame
	void Update () {
		if (gameState == GameState.START)
		{
			displayText.text = "COLOUR MATCH\nUP/DOWN: Change Colour\nRIGHT/LEFT: Change Panel";
			if (Input.anyKeyDown)
			{
				gameState = GameState.PLAYING;
			}
		} 
		else if (gameState == GameState.PLAYING)
		{
			displayText.text = string.Format("{0:0.00}", timeLimit);
			//Change Panel
			//if (Input.GetKeyDown(KeyCode.RightArrow))
			//{
			//	curPanel.bSelected = false;
			//	curPanel = getNextPanel(curPanel);
			//	curPanel.bSelected = true;
			//}
			//if (Input.GetKeyDown(KeyCode.LeftArrow))
			//{
			//	curPanel.bSelected = false;
			//	curPanel = getPrevPanel(curPanel);
			//	curPanel.bSelected = true;
			//}
			//if (Input.GetKey(KeyCode.UpArrow))
			//{
			//	curPanel.ChangeColor(true);
			//}
			//if (Input.GetKey(KeyCode.DownArrow))
			//{
			//	curPanel.ChangeColor(false);
			//}
		}
		else if (gameState == GameState.WIN)
		{
			displayText.text = "Congratulations!\nYou Passed!;";

			if (Input.anyKey)
			{
				Application.LoadLevel("Pass");
			}
		}
		else if (gameState == GameState.LOSS)
		{
			displayText.text = "Better Luck Next Time...\nYou Failed.";
			if (Input.anyKey)
			{
				Application.LoadLevel("Fail");
			}
		}

	}


	void FixedUpdate()
	{
		if (gameState == GameState.PLAYING)
		{
			timeLimit -= Time.fixedDeltaTime;
			if ( timeLimit <= 0.0f)
			{
				gameState = GameState.LOSS;
			}

			else if (firstPanel.bIsCorrect && secondPanel.bIsCorrect && thirdPanel.bIsCorrect)
			{
				gameState = GameState.WIN;
			}
		}
		
	}
}
