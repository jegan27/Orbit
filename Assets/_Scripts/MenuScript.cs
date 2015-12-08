using UnityEngine;
using UnityEngine.UI;// we need this namespace in order to access UI elements within our script
using System.Collections;

public class MenuScript : MonoBehaviour 
{
	public Canvas quitMenu;
	public Button startText;
	public Button exitText;
	public Button startText1;
	public Button startText2;
	public Button startText3;
	public Button startText4;
	public Button startText5;
	public Button startText6;

	void Start ()
		
	{
		quitMenu = quitMenu.GetComponent<Canvas>();
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		startText1 = startText.GetComponent <Button> ();
		startText2 = startText.GetComponent <Button> ();
		startText3 = startText.GetComponent <Button> ();
		startText4 = startText.GetComponent <Button> ();
		startText5 = startText.GetComponent <Button> ();
		startText6 = startText.GetComponent <Button> ();
		quitMenu.enabled = false;
		
	}
	
	public void ExitPress() //this function will be used on our Exit button
		
	{
		quitMenu.enabled = true; //enable the Quit menu when we click the Exit button
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
		quitMenu.enabled = false; //we'll disable the quit menu, meaning it won't be visible anymore
		startText.enabled = true; //enable the Play and Exit buttons again so they can be clicked
		exitText.enabled = true;
		startText1.enabled = true;
		startText2.enabled = true;
		startText3.enabled = true;
		startText4.enabled = true;
		startText5.enabled = true;
		startText6.enabled = true;
	}
	
	public void Docking () //this function will be used on our Play button
		
	{
		Application.LoadLevel (1); //this will load our first level from our build settings. "1" is the second scene in our game
		
	}
	public void Maze () //this function will be used on our Play button
		
	{
		//Application.LoadLevel(Random.Range( 4,6)); //this will load our first level from our build settings. "1" is the second scene in our game
		Application.LoadLevel(4);
		
	}
	public void Asteroids () //this function will be used on our Play button
		
	{
		Application.LoadLevel (10); //this will load our first level from our build settings. "1" is the second scene in our game
		
	}

	public void Audio () //this function will be used on our Play button
		
	{
		Application.LoadLevel ("Audio_Level_1"); //this will load our first level from our build settings. "1" is the second scene in our game
		
	}

	public void SineWave () //this function will be used on our Play button
		
	{
		Application.LoadLevel ("SineWave_Tutorial"); //this will load our first level from our build settings. "1" is the second scene in our game
		
	}
	public void Circuit () //this function will be used on our Play button
		
	{
		Application.LoadLevel ("Circuit_Level_1"); //this will load our first level from our build settings. "1" is the second scene in our game
		
	}
	public void ColourMatching () //this function will be used on our Play button
		
	{
		Application.LoadLevel ("ColourMatching_Level_1"); //this will load our first level from our build settings. "1" is the second scene in our game
		
	}



	public void ExitGame () //This function will be used on our "Yes" button in our Quit menu
		
	{
		Application.Quit(); //this will quit our game. Note this will only work after building the game
		
	}

	public void LoadCorey()
	{
		Application.LoadLevel (8);
	}

}