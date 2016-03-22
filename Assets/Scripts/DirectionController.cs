using UnityEngine;
using System.Collections;

public class DirectionController : MonoBehaviour
{
	private Vector2 dir;
	private Vector2 offset1;
	private Vector2 offset2;
	private  float spawnTime;

	public GameObject cell;


	private GameController gameController;
	private bool up, down, right, left;



	void Start ()
	{

		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		gameController = gameControllerObject.GetComponent<GameController > ();

		spawnTime = gameController.spawnTime;

		offset1 = new Vector2 (0.7f, 0.0f);
		offset2 = new Vector2 (0.0f, 0.7f);

		if (ComparePlayers ()) {
			up = true;  
			down = true;
			right = true;
			left = false;
			changeDirectionToRight ();
			InvokeRepeating ("Move", 0.32f, spawnTime);
		} else if (!ComparePlayers ()) {
			up = true;  
			down = true;
			right = false;
			left = true;
			changeDirectionToLeft ();
			InvokeRepeating ("Move", 0.3f, spawnTime);
		}
	
	}


	void LateUpdate ()
	{
		if (ComparePlayers ()) {
			if (Input.GetKey (KeyCode.S) == true & down == false) {
				changeDirectionToUp ();
			} else if (Input.GetKey (KeyCode.W) == true & up == false) {
				changeDirectionToDown ();
			} else if (Input.GetKey (KeyCode.D) == true & right == false) {
				changeDirectionToLeft ();
			} else if (Input.GetKey (KeyCode.A) == true & left == false) {
				changeDirectionToRight ();
			} else if (Input.GetKey (KeyCode.W)) {
				changeDirectionToUp ();
				up = true;
				left = true;
				right = true;
				down = false;
			} else if (Input.GetKey (KeyCode.S)) {
				changeDirectionToDown ();
				up = false;
				left = true;
				right = true;
				down = true;
			} else if (Input.GetKey (KeyCode.D)) {
				changeDirectionToRight ();
				up = true;
				left = false;
				right = true;
				down = true;
			} else if (Input.GetKey (KeyCode.A)) {
				changeDirectionToLeft ();
				up = true;
				left = true;
				right = false;
				down = true;
			}

		} else if (!ComparePlayers ()) {
			if (Input.GetKey (KeyCode.DownArrow) == true & down == false) {
				changeDirectionToUp ();
			} else if (Input.GetKey (KeyCode.UpArrow) == true & up == false) {
				changeDirectionToDown ();
			} else if (Input.GetKey (KeyCode.RightArrow) == true & right == false) {
				changeDirectionToLeft ();
			} else if (Input.GetKey (KeyCode.LeftArrow) == true & left == false) {
				changeDirectionToRight ();
			} else if (Input.GetKey (KeyCode.UpArrow)) {
				changeDirectionToUp ();
				up = true;
				left = true;
				right = true;
				down = false;
			} else if (Input.GetKey (KeyCode.DownArrow)) {
				changeDirectionToDown ();
				up = false;
				left = true;
				right = true;
				down = true;
			} else if (Input.GetKey (KeyCode.RightArrow)) {
				changeDirectionToRight ();
				up = true;
				left = false;
				right = true;
				down = true;
			} else if (Input.GetKey (KeyCode.LeftArrow)) {
				changeDirectionToLeft ();
				up = true;
				left = true;
				right = false;
				down = true;
			}

		}
	
	}

	bool ComparePlayers ()
	{
		bool player = true;
		if (gameObject.CompareTag ("Head_1")) {
			player = true;
		} else if (gameObject.CompareTag ("Head_2"))
			player = false;
		return player;
	}

	void Move ()
	{
		Vector2 v = transform.position;
		transform.Translate (dir);
		Instantiate (cell, v, transform.rotation);
	}

	void changeDirectionToUp ()
	{
		dir = Vector2.up + offset2;
	}

	void changeDirectionToDown ()
	{
		dir = Vector2.down - offset2;
	}

	void changeDirectionToLeft ()
	{
		dir = Vector2.left - offset1;
	}

	void changeDirectionToRight ()
	{
		dir = Vector2.right + offset1;
	}
		
}



