using System.Collections;
using UnityEngine;

public class DestroyByContact : MonoBehaviour 
{

	public GameObject explosion;
	public GameObject playerexplosion;
	public int scoreValue;
	private GameController gameController;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController> ();
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Boundary") 
		{
			return;
		}
		Instantiate (explosion, transform.position, transform.rotation);
		if (other.tag == "Player") 
		{
			Instantiate (playerexplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver ();
		}
		gameController.Addscore (scoreValue);
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}