using UnityEngine;
using System.Collections;

public class LoadingMinigames : MonoBehaviour {

	public void Asteroids ()
	{
		Application.LoadLevel ("Asteroids_Level_1");
	}

	public void Docking1 ()
	{
		Application.LoadLevel ("Docking_Level_1");
	}

	public void Docking2 ()
	{
		Application.LoadLevel ("Docking_Level_2");
	}

	public void Maze ()
	{
		Application.LoadLevel ("Maze_Level_2");
	}

	public void Circuit ()
	{
		Application.LoadLevel ("Circuit_Level_1");
	}

	public void SineWave ()
	{
		Application.LoadLevel ("SineWave_Level_1");
	}

	public void ColourMatching ()
	{
		Application.LoadLevel ("ColourMatching_Level_1");
	}

	public void Audio ()
	{
		Application.LoadLevel ("Audio_Level_1");
	}
}
