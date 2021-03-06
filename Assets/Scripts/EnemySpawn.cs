using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour
{
	public GameObject enemy;
	// Use this for initialization
	public void startInvoke ()
	{
		InvokeRepeating ("spawnTheEnemy", 0.5f, 7);
	}

	public void stopInvoke ()
	{
		CancelInvoke();
	}


	
	void spawnTheEnemy ()
	{
		int s1 = 0;
		int s2 = 0;
		int angleY = 0;

		int cornerNum = (int)Mathf.Ceil (Random.value * 4);
		if (cornerNum == 0)
			cornerNum = 1;
		switch (cornerNum) {
		case (1):
			s1 = 1;
			s2 = 1;
			angleY = Random.Range (180, 270);
			break;
		case (2):
			s1 = -1;
			s2 = +1;
			angleY = Random.Range (90, 180);
			break;
		case (3):
			s1 = -1;
			s2 = -1;
			angleY = Random.Range (0, 90);
			break;
		case (4):
			s1 = 1;
			s2 = -1;
			angleY = Random.Range (270, 360);
			break;
		}
		Instantiate (enemy, 
			new Vector3 (Random.Range (s1 * 13, s1 * 9), 0.25f, Random.Range (s2 * 13, s2 * 9)),
			Quaternion.Euler (0, angleY, 0));
	}


}
