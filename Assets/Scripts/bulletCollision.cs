using UnityEngine;
using System.Collections;

public class bulletCollision : MonoBehaviour
{
	GameController gamecontroller;
	// Use this for initialization
	void Start ()
	{
		GameObject GameControllerGO = GameObject.Find ("GameController");
		gamecontroller = GameControllerGO.GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (this.transform.position.y < 0) {
			//print ("fell");
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.name.IndexOf("Enemy") != -1) {
			print ("bullet collided with enemy");
			Destroy (other.gameObject);
			gamecontroller.updateScore (10);
		} 
		else if (other.gameObject.name == "Player") {
			print ("bullet collided with player");
			//Destroy (other.gameObject);
			other.gameObject.SetActive(false);
			gamecontroller.gameOver ();
		}
		Destroy (gameObject);
	}
}
