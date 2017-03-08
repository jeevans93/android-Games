
using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {

	public GameObject thePlatform;//new
	public Transform generationPoint;//new
	public float distanceBetween;

	private float platformWidth;

	public float distanceBetweenMin;
	public float distanceBetweenMax;

	private int platformSelector;//new

	private float[] platformWidths;

	public ObjectPooler[] theObjectPools;//new

	public float randomSpikeThreshold;
	public ObjectPooler spikePool;


	private ObstacleGenerator theObstacleGenerator;
	public float ObstacleGeneratorThreshold;
	public ObjectPooler obstaclePool;

	// Use this for initialization
	void Start () {

		//platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;

		platformWidths = new float[theObjectPools.Length];

		for (int i = 0; i < (theObjectPools.Length); i++) {

			platformWidths[i]= theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;


		}


		theObstacleGenerator = FindObjectOfType <ObstacleGenerator> ();

	}

	// Update is called once per frame
	void Update () {

		if (transform.position.x < generationPoint.position.x) {

			distanceBetween =3;
			platformSelector = 2;//Random.Range (0, theObjectPools.Length);

			transform.position = new Vector3 (transform.position.x + (platformWidths[platformSelector])/2f + distanceBetween, transform.position.y /*heightChange*/, transform.position.z);


			//Instantiate (/*thePlatform*/ theObjectPools[platformSelector], transform.position, transform.rotation);

			GameObject newPlatform =  theObjectPools[platformSelector].GetPooledObject ();

			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive (true);

			if (Random.Range (0f, 100f) < ObstacleGeneratorThreshold) {
				//if (transform.position.x < generationPoint.position.x){
				theObstacleGenerator.SpawnObstacles (new Vector3 (transform.position.x - 3 /*(for normal functinality)*/, transform.position.y, transform.position.z));
				//				GameObject newObstacle = obstaclePool.GetPooledObject ();
			}


		
		//	}
				

			/*        if (Random.Range (0f, 100f) < randomSpikeThreshold) {

                GameObject newSpike = spikePool.GetPooledObject ();

                float spikeXPosition = Random.Range (-platformWidths [platformSelector] / 2f+1f, platformWidths [platformSelector] / 2f-1f);

                Vector3 spikePosition = new Vector3 (spikeXPosition, 0.5f, 0f);

                newSpike.transform.position = transform.position + spikePosition;
                newSpike.transform.rotation = transform.rotation;
                newSpike.SetActive (true);
            }*/


			transform.position = new Vector3 (transform.position.x + (platformWidths[platformSelector])/2f , transform.position.y /*heightChange*/, transform.position.z);
		}



	}
}
