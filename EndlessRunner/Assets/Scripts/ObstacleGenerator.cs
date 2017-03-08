using UnityEngine;
using System.Collections;

public class ObstacleGenerator : MonoBehaviour {

	private int x;
	private int i;

	public ObjectPooler obstaclePool;

	public float distanceBetweenObstacles;

	public float ObstacleGeneratorThreshold;

	// Use this for initialization


		public void SpawnObstacles(Vector3 startPosition)
	{

		GameObject coin1 = obstaclePool.GetPooledObject ();
		coin1.transform.position = startPosition;
		coin1.SetActive(true);

			GameObject coin2 = obstaclePool.GetPooledObject ();
			coin2.transform.position = new Vector3 (startPosition.x, startPosition.y + distanceBetweenObstacles, startPosition.z);
			coin2.SetActive (true);

			GameObject coin3 = obstaclePool.GetPooledObject ();
			coin3.transform.position = new Vector3 (startPosition.x, startPosition.y - distanceBetweenObstacles, startPosition.z);
			coin3.SetActive (true);


			}

	}