using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public string playGameLevel;

	public void playGame(){

		Application.LoadLevel (playGameLevel);
	
	}

	public void quitGame(){
	
		Application.Quit ();
	
	}
}
