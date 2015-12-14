using UnityEngine;
using UnityEngine.UI;// we need this namespace in order to access UI elements within our script
using System.Collections;

public class MenuScript : MonoBehaviour 
{
	public Button startText;
	public Button exitText;
	public Button startText1;
	public Button startText2;
	public Button startText3;
	public Button startText4;
	public Button startText5;
	public Button startText6;

	string[] navigationLevels = new string[4] {"Docking Tutorial","Docking_Tute_2","Asteriods_tutorial","Maze_Level_2_Tutorial"}; 
	string[] communicationLevels = new string[4] {"Asteriods_tutorial","Maze_Level_2_Tutorial","AudioLevelTutorial","SineWave_Tutorial"}; 
	string[] researchLevels = new string[4] {"Docking Tutorial","Asteriods_tutorial","AudioLevelTutorial","ColourMatching_Level_1"}; 
	string[] maintenanceLevels = new string[4] {"Docking Tutorial","Maze_Level_2_Tutorial","AudioLevelTutorial","Circuit_Tutorial"}; 

	void Start ()
	{
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		startText1 = startText.GetComponent <Button> ();
		startText2 = startText.GetComponent <Button> ();
		startText3 = startText.GetComponent <Button> ();
		startText4 = startText.GetComponent <Button> ();
		startText5 = startText.GetComponent <Button> ();
		startText6 = startText.GetComponent <Button> ();
	}
	
	public void ExitPress() //this function will be used on our Exit button
	{
		startText.enabled = false;//then disable the Play and Exit buttons so they cannot be clicked
		exitText.enabled = false;
		startText1.enabled = false;
		startText2.enabled = false;
		startText3.enabled = false;
		startText4.enabled = false;
		startText5.enabled = false;
		startText6.enabled = false;
	}
	
	public void NoPress() //this function will be used for our "NO" button in our Quit Menu
	{
		startText.enabled = true; //enable the Play and Exit buttons again so they can be clicked
		exitText.enabled = true;
		startText1.enabled = true;
		startText2.enabled = true;
		startText3.enabled = true;
		startText4.enabled = true;
		startText5.enabled = true;
		startText6.enabled = true;
	}

	public void Navigation()
	{
		int randomIndex = Random.Range(0, navigationLevels.Length); 
		Application.LoadLevel(navigationLevels[randomIndex]); 
	}
	public void Maintenance()
	{
		int randomIndex = Random.Range(0, maintenanceLevels.Length); 
		Application.LoadLevel(maintenanceLevels[randomIndex]); 
	}
	public void Communication()
	{
		int randomIndex = Random.Range(0, communicationLevels.Length); 
		Application.LoadLevel(communicationLevels[randomIndex]); 
	}
	public void Research()
	{
		int randomIndex = Random.Range(0, researchLevels.Length); 
		Application.LoadLevel(researchLevels[randomIndex]); 
	}

}