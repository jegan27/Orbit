using UnityEngine;
using UnityEngine.UI;// we need this namespace in order to access UI elements within our script
using System.Collections;

public class MenuScript : MonoBehaviour 
{
	string[] navigationLevels = new string[4] {"Docking Tutorial","Docking_Tute_2","Asteriods_tutorial","Maze_Level_2_Tutorial"}; 
	string[] communicationLevels = new string[4] {"Asteriods_tutorial","Maze_Level_2_Tutorial","AudioLevelTutorial","SineWave_Tutorial"}; 
	string[] researchLevels = new string[4] {"Docking Tutorial","Asteriods_tutorial","AudioLevelTutorial","ColourMatching_Level_1"}; 
	string[] maintenanceLevels = new string[4] {"Docking Tutorial","Maze_Level_2_Tutorial","AudioLevelTutorial","Circuit_Tutorial"}; 

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
	public void ExitGame ()
	{
		Application.Quit();
	}
}