using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

	public string levelLoad;
	public float spawnTime;


	private  bool restart;

	void Start ()
	{
		restart = false; 
	
	}

	void Update ()
	{
		if (restart) {
			SceneManager.LoadScene (levelLoad);
			//Application.LoadLevel (levelLoad);
		}
	
	}

	public void restartTheGame ()
	{
		restart = true;
	}

}
