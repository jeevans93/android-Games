using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public string mainMenuLevel;
	public GameObject pauseMenu;

	public void pauseGame(){

		Time.timeScale = 0f;
		pauseMenu.SetActive (true);

	}

	public void resumeGame(){

		Time.timeScale = 1f;
		pauseMenu.SetActive (false);


	}

	public void restartGame(){

		Time.timeScale = 1f;
		pauseMenu.SetActive (false);
		FindObjectOfType<GameManager> ().reset ();

	}

	public void quitToMain(){

		Time.timeScale = 1f;
		Application.LoadLevel(mainMenuLevel);
	}
}
