using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
	public GameObject player;
	public Transform cylinderEnd;
	public GameObject bullet;
	public Transform turret;
	public float timeGapBetn2Shots = 1;
	public float startVelocity = 5;

	float nextShotAllowedAt = 0;
	float bulletVelocity = 35;
	GameController gamecontroller;

	// Use this for initialization
	void Start ()
	{
		Rigidbody enemyRB = this.GetComponent<Rigidbody> ();
		enemyRB.velocity = enemyRB.transform.forward * startVelocity;

		GameObject GameControllerGO = GameObject.Find ("GameController");
		gamecontroller = GameControllerGO.GetComponent<GameController> ();

	}
	
	// Update is called once per frame

	void Update ()
	{
		//turret.LookAt (player.transform);
		Vector3 distBetPlayerEnemy = player.transform.position - this.transform.position;

		//Debug.Log ("dist " + distBetPlayerEnemy.sqrMagnitude);
		if (distBetPlayerEnemy.sqrMagnitude < 200) {
			if (Time.time > nextShotAllowedAt) {
				GameObject bulletClone = (GameObject)Instantiate (bullet, cylinderEnd.position, Quaternion.identity);
				Rigidbody bulletCloneRB = bulletClone.GetComponent<Rigidbody> ();
				Physics.IgnoreCollision (this.GetComponent<Collider> (), bulletClone.GetComponent<Collider> ());
				Vector3 towardsPlayer = new Vector3 (player.transform.position.x - cylinderEnd.position.x,
					                        Mathf.Pow (Mathf.Pow (player.transform.position.x - cylinderEnd.position.x, 2) + Mathf.Pow (player.transform.position.z - cylinderEnd.position.z, 2), 0.5f),
					                        player.transform.position.z - cylinderEnd.position.z
				                        );
				towardsPlayer.Normalize ();
				bulletCloneRB.AddForce (towardsPlayer * bulletVelocity);
				nextShotAllowedAt = Time.time + timeGapBetn2Shots;
			}

		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.name == "Player") {
			Debug.Log ("enemy collided with player");
			other.gameObject.SetActive (false);
			gamecontroller.gameOver ();
		} else if (other.gameObject.name == "Ground") {
		} else
			Destroy (this.gameObject);
	}
}
