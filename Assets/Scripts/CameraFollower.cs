using UnityEngine;
using System.Collections;

public class CameraFollower : MonoBehaviour
{

	// Use this for initialization
	public GameObject player;
	Vector3 offset = new Vector3 (0, 4, -5);

	void Start ()
	{
		//this.transform.position = offset;
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
		this.transform.position = new Vector3 (player.transform.position.x +
		offset.z * Mathf.Sin ((Mathf.PI / 180) * player.transform.eulerAngles.y), 
			offset.y,
			player.transform.position.z +
			offset.z * Mathf.Cos ((Mathf.PI / 180) * player.transform.eulerAngles.y));
		//this.transform.Rotate (Quaternion.Euler (0, player.transform.eulerAngles.y, 0));
		this.transform.rotation = (Quaternion.Euler (15, player.transform.eulerAngles.y, 0));
	}
}
