using System.Collections;
using UnityEngine;

public class MailSpawner : MonoBehaviour
{
	private float timer = 0;
	public float respawnTime = 0f;
	private PlayerStats stats;

	public GameObject player;
	public GameObject[] mails;
	public GameObject spawnPoint;
	public float startingRespawnTime = 5f;
	public float mailThrowForce = 200f;

	private void Start()
	{
		if (player != null)
		{
			stats = player.GetComponent<PlayerStats>();
		}
	}
	
	private void Update()
	{
		if (stats != null)
		{
			respawnTime = startingRespawnTime - ((float)stats.level / (float)10);
		}

		timer += Time.deltaTime;
		if (timer >= respawnTime)
		{
			SpawnMail();
			timer = 0;
		}
	}

	private void SpawnMail()
	{
		GameObject obj = Instantiate(mails[Random.Range(0, mails.Length - 1)], spawnPoint.transform.position, spawnPoint.transform.rotation);
		Rigidbody rb = obj.GetComponent<Rigidbody>();
		rb.AddForce(0f, 0f, mailThrowForce);
	}
}
