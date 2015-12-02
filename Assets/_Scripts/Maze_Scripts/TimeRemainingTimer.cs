using UnityEngine;
using System.Collections;

public class TimeRemainingTimer : MonoBehaviour
{
    float countdownTimer = 30;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        countdownTimer -= Time.deltaTime;
    }
    void OnGUI()
    {
        if (countdownTimer > 0)
        {
            GUI.Label(new Rect(100, 100, 200, 100), "Time Remaining : " + (int)countdownTimer);
        }
        else
        {
            GUI.Label(new Rect(100, 100, 100, 100), "!!Time's Up!!");

			Application.LoadLevel("Fail");
        }

    }
}