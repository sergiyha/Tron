using UnityEngine;
using System.Collections;

public class outOfBounds : MonoBehaviour
{
	private GameController gameController;
	public bool firstPlayersCrashIntoWall, secondPlayerCrashIntoWall;

	void Start ()
	{
		firstPlayersCrashIntoWall = false;
		secondPlayerCrashIntoWall = false;
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		gameController = gameControllerObject.GetComponent<GameController> ();

	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.CompareTag ("Head_1")) {
			firstPlayersCrashIntoWall = true;
			gameController.restartTheGame ();
		} else if (other.CompareTag ("Head_2")) {
			secondPlayerCrashIntoWall = true;
			gameController.restartTheGame ();
		}
			
	}

}
