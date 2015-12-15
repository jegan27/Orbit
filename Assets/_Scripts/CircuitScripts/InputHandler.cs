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
		if (usingBoard)
		{
			Client = new TcpClient ("192.168.4.1", 80);
		}
	}


	public int JoystickX;
	public int JoystickY;
	public int DialPosition;
	public bool Button1;
	public bool Button2;



	// Update is called once per frame
	void Update () {

		if (Client != null)
		{
			if (Client.Available > 0) {
				byte [] buf = new byte[Client.Available];
				Client.GetStream().Read(buf, 0, Client.Available);
				string Input = System.Text.ASCIIEncoding.ASCII.GetString(buf);
                string [] Packets = Input.Split('@');
                if (Packets.Length > 0)
                {
                    string CurrentPacket = (Packets[Packets.Length - 2]);
                    string [] SensorData = (CurrentPacket.Split('^'));
                    JoystickX = int.Parse(  SensorData[0]);
                    JoystickY = int.Parse(SensorData[1]);
                    DialPosition = int.Parse(SensorData[2]);
                    Button1 = (SensorData[3] == "1");
                    Button2 = (SensorData[4] == "1");
                    string Test = string.Format("{0} - {1} - {2} - {3} - {4}", JoystickX, JoystickY, DialPosition, Button1, Button2);
                    Debug.Log(Test);

                }

            }
			
		}
	}
}
