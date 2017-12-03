using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Pickup : MonoBehaviour
{
	private Rigidbody rb;
	private Collider cldr;

	public GameObject player;
	public string type;
	public float moneyIncrement = 10f;
	public long xpIncrement = 100;
	public float moneyDecrement = 20f;
	public float moneyDecrementOnWait = 0.1f;
	
	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		cldr = GetComponent<Collider>();
		player = GameObject.Find("Player");
	}

	private void Update()
	{
		if (player != null)
		{
			PlayerStats stats = player.GetComponent<PlayerStats>();

			stats.money -= moneyDecrementOnWait * Time.deltaTime;
		}
	}

	public void Pick(Transform newParent)
	{
		// Set parent
		transform.SetParent(newParent, false);
		// Reset rotation
		transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
		// Reset position
		transform.position = newParent.position;
		// Disable rigidbody parameters
		rb.useGravity = false;
		rb.isKinematic = true;
		// Disable collider
		cldr.enabled = false;
	}

	public void Throw(float force)
	{
		// Clear parent
		transform.parent = null;
		// Enable rigidbody paramets
		rb.useGravity = true;
		rb.isKinematic = false;
		// Enable colleider
		cldr.enabled = true;
		// Apply force to rigidbody
		rb.AddRelativeForce(new Vector3(0f, force / 2, force));
	}
}
