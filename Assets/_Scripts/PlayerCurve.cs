using UnityEngine;
using System.Collections;

public class PlayerCurve : MonoBehaviour 
{

	LineRenderer m_renderer;
	float m_Timer;
	
	public float fSpeed = 1f;
	public float fFrequency = 1f;
	public float fHeight = 3f;

	bool UsingBoard = false;
	InputHandler manager;

	float min = 10;
	float max = 30;

	// Use this for initialization
	void Start () 
	{
		m_renderer = GetComponent<LineRenderer>();
		manager = GetComponent<InputHandler> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		m_Timer += Time.fixedDeltaTime;

		for (float i = 0f; i< 150f; i++) 
		{
			m_renderer.SetPosition((int)i, new Vector3((i/25f), Mathf.Sin((i/25) * fFrequency + (m_Timer * fSpeed) * fHeight), 0f));
		};

		if (!UsingBoard) 
		{
			if (Input.GetKey (KeyCode.F)) 
			{
				if (Input.GetKeyDown (KeyCode.LeftArrow))
					fFrequency -= 0.1f;
				if (Input.GetKeyDown (KeyCode.RightArrow))
					fFrequency += 0.1f;

			}
			if (Input.GetKey (KeyCode.S)) 
			{
				if (Input.GetKeyDown (KeyCode.LeftArrow))
					fSpeed -= 0.1f;
				if (Input.GetKeyDown (KeyCode.RightArrow))
					fSpeed += 0.1f;
			}
		} 
		else 
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

}
