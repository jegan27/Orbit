using UnityEngine;
using System.Collections;

public class tutcurve : MonoBehaviour {

	LineRenderer m_renderer;
	float m_Timer;
	
	public float m_fSpeed;
	public float m_fFrequency;
	public float m_fHeight;

	// Use this for initialization
	void Start () {

		m_fSpeed = (float)Random.Range (10, 30) * 0.1f;
		m_fFrequency = (float)Random.Range (10, 30) * 0.1f;
		m_fHeight = 3f;
		
		m_renderer = GetComponent<LineRenderer>();
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		m_Timer += Time.fixedDeltaTime;
		
		for (float i = 0f; i< 150f; i++) {
			m_renderer.SetPosition((int)i, new Vector3((i/25f), Mathf.Sin((i/25) * m_fFrequency + (m_Timer * m_fSpeed)* m_fHeight), 0f));
		};
	
	}

	public void LoadLevel(int level)
	{
		Application.LoadLevel ("SineWave_Level_1");
	}
}
