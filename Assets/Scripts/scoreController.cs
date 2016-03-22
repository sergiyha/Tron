using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scoreController : MonoBehaviour
{

	public GameObject ScoreCanvas;
	public Text pinkSetScore;
	public Text greenSetScore;
	public Text greenMainScore;
	public Text pinkMainScore;

	private outOfBounds outOfBounds;
	private TriggerController firstTriggercontroller;
	private TriggerController secondTriggercontroller;

	private GameObject instantiatedGameObject;
	private float time;

	// Use this for initialization
	void Start ()
	{
		GameObject outOfBoundsObject = GameObject.FindWithTag ("outOfBounds");
		outOfBounds = outOfBoundsObject.GetComponent<outOfBounds> ();

		GameObject firstTriggerControllerObject = GameObject.FindWithTag ("Head_1");
		firstTriggercontroller = firstTriggerControllerObject.GetComponent<TriggerController> ();

		GameObject secondTriggerControllerObject = GameObject.FindWithTag ("Head_2");
		secondTriggercontroller = secondTriggerControllerObject.GetComponent<TriggerController> ();

		time = 0.0f;
	}

	void Update ()
	{

		if (PlayerPrefs.GetInt ("SetPink") == 3) {
			pinkSetScore.text = "0";
			greenSetScore.text = "0";
			PlayerPrefs.SetInt ("SetPink", 0);
			PlayerPrefs.SetInt ("SetGreen", 0);
			SetPinkMainScore ();

		} else if (PlayerPrefs.GetInt ("SetGreen") == 3) {
			pinkSetScore.text = "0";
			greenSetScore.text = "0";
			PlayerPrefs.SetInt ("SetPink", 0);
			PlayerPrefs.SetInt ("SetGreen", 0);
			SetGreenMainScore ();
		}





		//Refresh score
		if (Input.GetKeyDown (KeyCode.R)) {
			PlayerPrefs.DeleteAll ();
			pinkSetScore.text = "0";
			pinkMainScore.text = "0";
			greenSetScore.text = "0";
			greenMainScore.text = "0";

		}


		//Push TAB
		if (Input.GetKeyDown (KeyCode.Tab)) {
			Debug.Log ("TAB");
			instantiatedGameObject = (GameObject)Instantiate (ScoreCanvas, transform.position, Quaternion.identity);
			Time.timeScale = 0;
		}
		if (Input.GetKeyUp (KeyCode.Tab)) {
			DestroyObject (instantiatedGameObject, time);
			Time.timeScale = 1;
		}




		//Green is defeated
		if (outOfBounds.firstPlayersCrashIntoWall == true) {
			SetGreenSetScore ();
			outOfBounds.firstPlayersCrashIntoWall = false;
		} else if (firstTriggercontroller.firstHeadCrashIntoEnemyCell == true) {
			SetGreenSetScore ();
			firstTriggercontroller.firstHeadCrashIntoEnemyCell = false;
		} 



		//Pink is defeated
		if (outOfBounds.secondPlayerCrashIntoWall == true) {
			SetPinkSetScore ();
			outOfBounds.secondPlayerCrashIntoWall = false;
		} else if (secondTriggercontroller.secondHeadCrashIntoEnemyCell == true) {
			SetPinkSetScore ();
			secondTriggercontroller.secondHeadCrashIntoEnemyCell = false;
		}  


	
	}

	void SetPinkSetScore ()
	{
		int score = PlayerPrefs.GetInt ("SetPink") + 1;
		PlayerPrefs.SetInt ("SetPink", score);
		pinkSetScore.text = PlayerPrefs.GetInt ("SetPink").ToString ();
	}

	void SetGreenSetScore ()
	{
		int score = PlayerPrefs.GetInt ("SetGreen") + 1;
		PlayerPrefs.SetInt ("SetGreen", score);
		greenSetScore.text = PlayerPrefs.GetInt ("SetGreen").ToString ();
	}

	void SetPinkMainScore ()
	{
		int score = PlayerPrefs.GetInt ("MainPink") + 1; 
		PlayerPrefs.SetInt ("MainPink", score);
		pinkMainScore.text = PlayerPrefs.GetInt ("MainPink").ToString ();
	}

	void SetGreenMainScore ()
	{
		int score = PlayerPrefs.GetInt ("MainGreen") + 1; 
		PlayerPrefs.SetInt ("MainGreen", score);
		greenMainScore.text = PlayerPrefs.GetInt ("MainGreen").ToString ();
	}


}
