using UnityEngine;
using System.Collections;
using System.Net.Sockets;
using System.IO;


enum EMessageType
{
	Dial,
	Joystick,
	Button1,
	Button2,
	RGBLED,
	RedLED,
	GreenLED,
	BlueLED,
	OrangeLED,
	MinigameType
	
};
//perhaps we should handle the need to reconnect?

public class InputHandler : MonoBehaviour {

	public bool usingBoard = false;
	private TcpClient Client;
	// Use this for initialization
	void Start () {
		Client = new TcpClient ("192.168.4.1", 80);
	}
	public int JoystickX;
	public int JoystickY;
	public int DialPosition;
	public bool Button1;
	public bool Button2;
	
	
	// Update is called once per frame
	void Update () {
		if (Client != null) {
			if (Client.Available > 0) {
				byte [] buf = new byte[8];
				Client.GetStream ().Read (buf, 0, Client.Available);
				
				switch ((EMessageType)(buf [0])) {
				case EMessageType.Dial:
					DialPosition = buf [1];
					break;
				case EMessageType.Button1:
					Button1 = (buf [1] != 0) ? true : false; 
					break;
				case EMessageType.Button2:
					Button2 = (buf [1] != 0) ? true : false; 
					break;
				case EMessageType.Joystick:
					JoystickX = buf [1];
					JoystickY = buf [2];
					break;
				}
			}
		}
			//Debug.Log(System.Text.ASCIIEncoding.ASCII.GetString(buf));
	}
}
