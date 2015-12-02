using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	public int m_time;
	public GUIText guitimer;
	
	void Start()
	{
		StartCoroutine (countdown());
	}
	
	IEnumerator countdown()
	{
		while (m_time > 0)
		{
			yield return new WaitForSeconds(1);
			
			guitimer.text = m_time.ToString();
			
			m_time -= 1;
		}
		Application.LoadLevel ("Fail");
	}
}