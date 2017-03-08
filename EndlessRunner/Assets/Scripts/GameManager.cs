using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Transform platformGenerator;
	private Vector3 platformStartPoint;

	public PlayerController thePlayer;
	private Vector3 playerStartPoint;

	private ScoreManager theScoreManager;

	public DeathMenu theDeathScreen;

	private PlatformDestroyer[] platformList;
	// Use this for initialization
	void Start () {

		platformStartPoint = platformGenerator.position;
		playerStartPoint = thePlayer.transform.position;

		theScoreManager = FindObjectOfType<ScoreManager> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RestartGame()
	{
		theScoreManager.scoreIncreasing = false;
		thePlayer.gameObject.SetActive (false);
		//StartCoroutine ("restartGameCo");

		theDeathScreen.gameObject.SetActive (true);
	}

	public void reset()
	{	
		theDeathScreen.gameObject.SetActive (false);
		platformList = FindObjectsOfType<PlatformDestroyer> ();
		for (int i = 0; i < platformList.Length; i++) {

			platformList [i].gameObject.SetActive (false);

		}
		thePlayer.transform.position = playerStartPoint;
		platformGenerator.position = platformStartPoint;
		thePlayer.gameObject.SetActive (true);

		theScoreManager.scoreCount = 0;
		theScoreManager.scoreIncreasing = true;
	}

	/*public IEnumerator restartGameCo()
	{
		theScoreManager.scoreIncreasing = false;
		thePlayer.gameObject.SetActive (false);
		yield return new WaitForSeconds (0.5f);

		platformList = FindObjectsOfType<PlatformDestroyer> ();
		for (int i = 0; i < platformList.Length; i++) {
		
			platformList [i].gameObject.SetActive (false);
		
		}
		thePlayer.transform.position = playerStartPoint;
		platformGenerator.position = platformStartPoint;
		thePlayer.gameObject.SetActive (true);

		theScoreManager.scoreCount = 0;
		theScoreManager.scoreIncreasing = true;
	}*/
}
