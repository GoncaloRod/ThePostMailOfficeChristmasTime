using UnityEngine;

public class CarSpawn : MonoBehaviour
{
	public GameObject car;
	public GameObject spawnPoint;
	public float firstSpawnTime = 2f;
	public float respawnSpeed = 5f;

	void Start()
	{
		InvokeRepeating("SpawnCar", firstSpawnTime, respawnSpeed);
	}

	void SpawnCar()
	{
		Instantiate(car, spawnPoint.transform.position, spawnPoint.transform.rotation);
	}
}
