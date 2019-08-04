using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	public GameObject enemy;
	public GameObject buttons;
	public Text restartText;
	public Text gameOverText;
	public Text ScoreText;

	private int score = 0;
	private int level = 1;
	EnemyMovement enemymovement;

	private bool isGameOver = false;
	// Use this for initialization
	void Start ()
	{
		enemymovement = enemy.GetComponent<EnemyMovement> ();
		restartText.text = "";
		gameOverText.text = "";
		ScoreText.text = "Score : 0";
		InvokeRepeating ("spawnTheEnemy", 0.5f, 4);
		enemymovement.timeGapBetn2Shots = 1 - ((level - 1) * 0.1f);
		enemymovement.startVelocity = 5 + ((level - 1) * 2);
		showLevelText ();

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isGameOver == true && Input.GetKey (KeyCode.R)) {
			//restart
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}
	}

	public void updateScore (int incr)
	{
		score += incr;
		ScoreText.text = "Score : " + score;
		if (score % 50 == 0) {
			level++;
			showLevelText ();
			enemymovement.timeGapBetn2Shots = 1 - ((level - 1) * 0.1f);
			enemymovement.startVelocity = 5 + ((level - 1) * 2);
			CancelInvoke ();
			InvokeRepeating ("spawnTheEnemy", 0.5f, (4 - ((level - 1) * 0.5f)));
			//print ("IR " + (4 - ((level - 1) * 0.5f)));
		}
	}

	public void gameOver ()
	{
		CancelInvoke ();
		enemymovement.timeGapBetn2Shots = 1;
		enemymovement.startVelocity = 5;
		restartText.text = "Press 'R' to restart";
		gameOverText.text = "Game Over";
		ScoreText.text = "Score : " + score;
		buttons.SetActive (false);
		isGameOver = true;
	}

	void showLevelText ()
	{
		StartCoroutine ("ShowLevelNumFor2Sec");
	}

	IEnumerator ShowLevelNumFor2Sec ()
	{
		gameOverText.text = "Level " + level;
		yield return new WaitForSeconds (2);
		gameOverText.text = "";
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