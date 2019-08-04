using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
	//spublic GameObject player;
	// Use this for initialization
	public Transform cylinderEnd;
	public GameObject bullet;
	public float bulletVelocity;

	int linearVelocity = 15;
	int angularVelocity = 60;
	//Rigidbody playerRB;
	float timeGapBetn2Shots = 0.5f;
	float nextShotAllowedAt = 0;

	bool up = false;
	bool down = false;
	bool left = false;
	bool right = false;
	bool fire = false;

	void Start ()
	{
		Vector3 originalPosition = new Vector3 (0f, 0.25f, -10f);
		this.transform.position = originalPosition;
		//playerRB = this.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame


	void Update ()
	{
	}



	void FixedUpdate ()
	{
//		if (Input.GetKey (KeyCode.UpArrow))
//			playerRB.AddForce (transform.forward * linearVelocity);
//		if (Input.GetKey (KeyCode.DownArrow))
//			playerRB.AddForce (transform.forward * -1 * linearVelocity);

		//if (transform.position.x > -13 && transform.position.x < 13 && transform.position.z > -13 && transform.position.z < 13) {
		if (Input.GetKey (KeyCode.UpArrow) || up == true) {
			//playerRB.MovePosition (transform.position + Vector3.forward * Time.deltaTime * linearVelocity);
			this.transform.Translate (Vector3.forward * Time.deltaTime * linearVelocity);
		}
		if (Input.GetKey (KeyCode.DownArrow) || down == true) {
			//playerRB.MovePosition (transform.position + Vector3.forward * Time.deltaTime * -1 * linearVelocity);
			this.transform.Translate (Vector3.forward * Time.deltaTime * -1 * linearVelocity);
		}
		if (Input.GetKey (KeyCode.LeftArrow) || left == true) {
			//playerRB.MoveRotation (Quaternion.Euler (0, transform.rotation.eulerAngles.y + angularVelocity * -1 * Time.deltaTime, 0));
			this.transform.Rotate (Vector3.up * Time.deltaTime * -1 * angularVelocity);
		}
		if (Input.GetKey (KeyCode.RightArrow) || right == true) {
			//playerRB.MoveRotation (Quaternion.Euler (0, transform.rotation.eulerAngles.y + angularVelocity * Time.deltaTime, 0));
			this.transform.Rotate (Vector3.up * Time.deltaTime * angularVelocity);
		}
		//}

		this.transform.position = new Vector3 (Mathf.Clamp (transform.position.x, -13f, 13f), 0.25f, Mathf.Clamp (transform.position.z, -13f, 13f));
		//playerRB.position = new Vector3 (Mathf.Clamp (playerRB.position.x, -13f, 13f), 0.0f, Mathf.Clamp (playerRB.position.z, -13f, 13f));


		if ((Input.GetKey (KeyCode.Space) || fire == true) && Time.time > nextShotAllowedAt) {
			GameObject bulletClone = (GameObject)Instantiate (bullet, cylinderEnd.position, Quaternion.identity);
			Rigidbody bulletCloneRB = bulletClone.GetComponent<Rigidbody> ();
			Physics.IgnoreCollision (this.GetComponent<Collider> (), bulletClone.GetComponent<Collider> ());
			bulletCloneRB.AddForce (cylinderEnd.forward * -1 * bulletVelocity);
			nextShotAllowedAt = Time.time + timeGapBetn2Shots;
		}
	}


	public void setUPtrue ()
	{
		up = true;
	}

	public void setUPfalse ()
	{
		up = false;
	}

	public void setDOWNtrue ()
	{
		down = true;
	}

	public void setDOWNfalse ()
	{
		down = false;
	}

	public void setLEFTtrue ()
	{
		left = true;
	}

	public void setLEFTfalse ()
	{
		left = false;
	}

	public void setRIGHTtrue ()
	{
		right = true;
	}

	public void setRIGHTfalse ()
	{
		right = false;
	}

	public void setFIREtrue ()
	{
		fire = true;
	}

	public void setFIREfalse ()
	{
		fire = false;
	}

}

