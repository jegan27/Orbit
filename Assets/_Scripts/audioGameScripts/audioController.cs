using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class audioController : MonoBehaviour 
{
	public Slider sliderStatic;
	public Slider sliderBuzz;
	
	public Text m_Scorebox;
	
	public AudioSource audioBuzz;
	public AudioSource audioStatic;
	
	public AudioSource audioBeep;



	public int counter = 0;
	
	float m_fTimer = 0.0f;
	float m_fBeat;
	
	float buzz0;
	float static0;


	
	int correctBeats = 0;
	
	bool beepGuard = false;
	bool pressGuard = false;


	new InputHandler boardManager;
	
	// Use this for initialization
	void Start () 
	{


		boardManager = GameObject.FindGameObjectWithTag ("InputHandler").GetComponent<InputHandler> ();

		if (sliderStatic == null)
		{
			Debug.Log("Bump");
		}
		sliderBuzz.value = Random.Range (-9f, 9f);
		sliderStatic.value = Random.Range (-9f, 9f);
		
		buzz0 = Random.Range (-8f, 8f);
		static0 = Random.Range (-8f, 8f);
		
		m_fBeat = (float)Random.Range (3, 7) * 0.5f;
		Debug.Log (m_fBeat);
		Debug.Log (m_fTimer);
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{


		m_fTimer = Mathf.Repeat(m_fTimer + Time.fixedDeltaTime, m_fBeat);
		Debug.Log (m_fTimer);


		if (boardManager.usingBoard) {
			sliderStatic.value = Mathf.Clamp((float)(boardManager.JoystickX - 128) /12.8f, -10f, 10f);
			sliderBuzz.value = Mathf.Clamp((float)(boardManager.JoystickY - 128) /12.8f, -10f, 10f);
		}

		float volumePerc = ((10f + sliderStatic.value) - (10f + static0)) / (-(10f + static0));
		volumePerc *= Mathf.Sign (volumePerc);
		audioStatic.volume = volumePerc;
		
		if (!boardManager.usingBoard) {
			if (sliderStatic.value >= static0) {
				sliderStatic.value += 0.03f * volumePerc;
			} else {
				sliderStatic.value -= 0.03f * volumePerc;
				;
			}
		}
		volumePerc = ((10f + sliderBuzz.value) - (10f + buzz0)) / (-(10f + buzz0));
		volumePerc *= Mathf.Sign (volumePerc);
		audioBuzz.volume = volumePerc;

		if (!boardManager.usingBoard) {
			if (sliderBuzz.value >= buzz0) {
				sliderBuzz.value += 0.030f * volumePerc;
			} else {
				sliderBuzz.value -= 0.030f * volumePerc;
				;
			}
		}

		if (isStaticLow() && isBuzzLow()) {
			if (m_fTimer <= 0.3f)
			{
				if (!beepGuard)
				{
					audioBeep.Play();
					beepGuard = true;
				}
			}
			else if (m_fTimer > 0.3f)
			{
				beepGuard = false;
				pressGuard = false;
				
			}
		}
		m_Scorebox.text = string.Format ("Beats Left: {0}", 3 - correctBeats);

	}
	
	bool isStaticLow ()
	{
		if (Mathf.Sign (sliderStatic.value - static0) * (sliderStatic.value - static0) <= 1.5f) {
			return true;
		}
		return false;
		//
	}
	
	bool isBuzzLow ()
	{
		if (Mathf.Sign (sliderBuzz.value - buzz0) * (sliderBuzz.value - buzz0) <= 1.5f) {
			return true;
		}
		return false;
		//
	}

	public void isButtonBeingPressed()
	{
		if (isStaticLow () && isBuzzLow ()) {
			if (m_fTimer <= 0.5f && !pressGuard) {
				correctBeats++;
				counter ++;
				pressGuard = true;
			}


		}
		if(counter ==3)
		{
			Application.LoadLevel("Pass");
		}
	}
}
