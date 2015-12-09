using UnityEngine;
using System.Collections;

public class Done_GameController : MonoBehaviour
{
	public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	

	public GUIText restartText;
	public GUIText gameOverText;
	public GUIText eventSuccessfulText;
	public GUIText timeRemainingText;
	
	private bool gameOver;


	float timeRemaining = 23.0f;

	void Start ()
	{
		gameOver = false;

		restartText.text = "";
		gameOverText.text = "";
		eventSuccessfulText.text = "";
		timeRemainingText.text = "";
	
		StartCoroutine (SpawnWaves ());
	}
	
	void Update ()
	{
		if (!gameOver)
		{
			timeRemaining -= Time.deltaTime;
		}

	}
	
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				GameObject hazard = hazards [Random.Range (0, hazards.Length)];
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			

		}
	}
	

	public void GameOver ()
	{

		gameOverText.text = "Mission failed";
		gameOver = true;
		Application.LoadLevel("Fail");
	}
	void OnGUI()
	   	{
		if(timeRemaining > 0){
			timeRemainingText.text = "Time Remaining : "+(int)timeRemaining; 
			     
		}
		else{

			eventSuccessfulText.text = "Mission Successful ";
			Time.timeScale = 0;
			Application.LoadLevel("Pass");
		}
	}
}