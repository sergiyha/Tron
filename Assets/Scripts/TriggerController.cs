using UnityEngine;
using System.Collections;

public class TriggerController : MonoBehaviour
{
	[HideInInspector]
	public bool firstHeadCrashIntoEnemyHead, firstHeadCrashIntoEnemyCell;
	public bool secondHeadCrashIntoEnemyCell, secondHeadCrashIntoEnemyHead;

	private bool firstGamePlayer;
	private bool secondGamePlayer;
	private GameController gameController;

	// Use this for initialization
	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		gameController = gameControllerObject.GetComponent<GameController > ();

		firstHeadCrashIntoEnemyHead = false;
		firstHeadCrashIntoEnemyCell = false;
		secondHeadCrashIntoEnemyCell = false;
		secondHeadCrashIntoEnemyHead = false;

	
	}

	void Update ()
	{
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (gameObject.CompareTag ("Head_1")) {
			if (other.CompareTag ("Head_2") || other.CompareTag ("cell")) {
				Debug.Log ("Head");
				if (other.CompareTag ("Head_2")) {
					Debug.Log ("Head");
					firstHeadCrashIntoEnemyHead = true;
				} else if (other.CompareTag ("cell")) {
					Debug.Log ("cell");	
					firstHeadCrashIntoEnemyCell = true;
				}
				gameController.restartTheGame ();
			}
		} else if (gameObject.CompareTag ("Head_2")) {
			if (other.CompareTag ("Head_1") || other.CompareTag ("cell")) {
				if (other.CompareTag ("Head_1")) {
					secondHeadCrashIntoEnemyHead = true;
					Debug.Log ("Head");

				} else if (other.CompareTag ("cell")) {
					secondHeadCrashIntoEnemyCell = true;
					Debug.Log ("cell");	
				}
				gameController.restartTheGame ();
			}
		}

	}
}
