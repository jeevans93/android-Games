using UnityEngine;
using System.Collections;

public class Powerups : MonoBehaviour {

	public bool doublePoints;
	public bool safeMode;

	private PowerUpManager thePowerupManager;
	public float powerupLength;

	// Use this for initialization
	void Start () {

		thePowerupManager = FindObjectOfType<PowerUpManager> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player") {
		
			thePowerupManager.ActivatePowerup (doublePoints, safeMode, powerupLength);
		
		}
		gameObject.SetActive (false);
	}
}
