using UnityEngine;
using System.Collections;

public class ColorPanel : MonoBehaviour {

	// Use this for initialization

	public int PanelNumber = 0;
	public ColorChanger colorChanger;
	Color TargetColor;
	public Color curColor;

	public int iCompToChange;

	public Light lightIndicator;

	public bool bSelected = false;

	public bool bIsCorrect = false;

	void Start () {
		if (TargetColor == null)
		{
			Debug.LogError("No Colour to Target!", this);
			return;
		}
		switch (PanelNumber)
		{
			case 1:
				{
					TargetColor = colorChanger.firstColor;
					break;
				}
			case 2:
				{
					TargetColor = colorChanger.secondColor;
					break;
				}
			case 3:
				{
					TargetColor = colorChanger.thirdColor;
					break;
				}
			default:
				{
					TargetColor = colorChanger.firstColor;
					break;
				}
		}
		iCompToChange = Random.Range(1,4);
		switch (iCompToChange)
		{
			case 1:
				{
					curColor = new Color(Random.Range(0.0f, 1.0f), TargetColor.g, TargetColor.b);
					break;
				}
			case 2:
				{
					curColor = new Color(TargetColor.r, Random.Range(0.0f, 1.0f), TargetColor.b);
					break;
				}
			case 3:
				{
					curColor = new Color(TargetColor.r, TargetColor.g, Random.Range(0.0f, 1.0f));
					break;
				}
			default:
				{
					curColor = TargetColor;
					break;
				}
		}
	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<Renderer>().material.color = curColor;
		if (isColorSame())
		{
			lightIndicator.color = Color.green;
			bIsCorrect = true;
		}
		else if (bSelected)
		{
			lightIndicator.color = Color.yellow;
		}
		else
		{
			bIsCorrect = false;
			lightIndicator.color = Color.red;
		}
	
	}

	bool isColorSame()
	{
		int rightColours = 0;
		//Check if Colours are similar.
		if ((curColor.r - TargetColor.r) * Mathf.Sign(curColor.r - TargetColor.r) < 0.025)
		{
			rightColours++;
		}
		if ((curColor.g - TargetColor.g) * Mathf.Sign(curColor.g - TargetColor.g) < 0.025)
		{
			rightColours++;
		} if ((curColor.b - TargetColor.b) * Mathf.Sign(curColor.b - TargetColor.b) < 0.025)
		{
			rightColours++;
		}

		if (rightColours == 3)
			return true;
		return false;
	}

	public void ChangeColor(float newCol)
	{
		switch (iCompToChange)
		{
			case 1:
				{
					curColor.r = newCol;
					break;
				}
			case 2:
				{
					curColor.g = newCol;
					break;
				}
			case 3:
				{
					curColor.b = newCol;
					break;
				}
			default:
				{
					//
					break;
				}
		}
	}

	public float getCurHue()
	{
		switch (iCompToChange)
		{
			case 1:
				{
					return curColor.r;
					//break;
				}
			case 2:
				{
					return curColor.g;
					//break;
				}
			case 3:
				{
					return curColor.b;
					//break;
				}
			default:
				{
					return 0.0f;
					//break;
				}
		}
	}
}
