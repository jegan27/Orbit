using UnityEngine;
using System.Collections;

public class IntroCurve : MonoBehaviour {

	LineRenderer m_renderer;
	float m_Timer;
	public float m_fSpeed;
	public float m_fFrequency;
	public float m_fHeight;

	// Use this for initialization
	void Start () 
	{
		m_fSpeed = 3f;
		m_fFrequency = 3f;
		m_fHeight = 3f;
		m_renderer = GetComponent<LineRenderer>();
	}
	
	void FixedUpdate () 
	{
		m_Timer += Time.fixedDeltaTime;
		
		for (float i = 0f; i< 150f; i++) {
			m_renderer.SetPosition ((int)i, new Vector3 ((i / 25f), Mathf.Sin ((i / 25) * m_fFrequency + (m_Timer * m_fSpeed) * m_fHeight), 0f));
		}
		;
	}

	public void loadGame()
	{
		Application.LoadLevel("SineWave_Level_1");
	}

}
