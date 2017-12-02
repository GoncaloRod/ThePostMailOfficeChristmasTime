using UnityEngine;

public class MailSpawner : MonoBehaviour
{
	public GameObject[] mails;
	public GameObject spawnPoint;
	public float firstSpawnTime = 5f;
	public float respawnTime = 5f;
	public float mailThrowForce = 200f;

	private void Start ()
	{
		InvokeRepeating("SpawnMails", firstSpawnTime, respawnTime);
	}

	private void SpawnMails()
	{
		GameObject obj = Instantiate(mails[Random.Range(0, mails.Length - 1)], spawnPoint.transform.position, spawnPoint.transform.rotation);
		Rigidbody rb = obj.GetComponent<Rigidbody>();
		rb.AddForce(0f, 0f, mailThrowForce);
	}
}
