using UnityEngine;
using System.Collections;

public class PlayerCurve : MonoBehaviour 
{

	LineRenderer m_renderer;
	float m_Timer;
	
	public float fSpeed = 1f;
	public float fFrequency = 1f;
	public float fHeight = 3f;

	InputHandler manager;

	public Color c1 = Color.red;
	public Color c2 = new Color(0, 1, 1, 1);

	float min = 10;
	float max = 30;

	// Use this for initialization
	void Start () 
	{
		m_renderer = GetComponent<LineRenderer>();
		m_renderer.material = new Material(Shader.Find("Particles/Additive"));
		m_renderer.SetColors(c2,c1 );

		manager = GameObject.FindGameObjectWithTag ("InputHandler").GetComponent<InputHandler> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		m_Timer += Time.fixedDeltaTime;

		for (float i = 0f; i< 150f; i++) 
		{
			m_renderer.SetPosition((int)i, new Vector3((i/25f), Mathf.Sin((i/25) * fFrequency + (m_Timer * fSpeed) * fHeight), 0f));
		};

		if (manager.usingBoard) 
		{
			float alpha = manager.DialPosition/255;
			if(manager.Button1)
			{
				fFrequency = Mathf.Lerp (min, max, alpha);
			}
			if(manager.Button2)
			{
				fSpeed = Mathf.Lerp (min, max, alpha);
			}
		}
			
	}

	public void changeFrequency(float freqChange)
	{

		fFrequency += freqChange;

	}
	public void changeSpeed(float speedChange)
	{
		
		fSpeed += speedChange;
		
	}

}
