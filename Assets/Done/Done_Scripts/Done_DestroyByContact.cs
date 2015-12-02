using UnityEngine;
using System.Collections;

public class Done_DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;

	private Done_GameController gameController;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <Done_GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Boundary" || other.tag == "Enemy")
		{
			return;
		}

		if (explosion != null)
		{
			GameObject explosionFX = (GameObject) Instantiate(explosion, transform.position, transform.rotation);
			explosionFX.transform.localScale = new Vector3(3,3,3);

		}

		if (other.tag == "Player")
		{


			gameController.GameOver();
		}
		

		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}