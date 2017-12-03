using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Pickup : MonoBehaviour
{
	private Rigidbody rb;
	private Collider cldr;

	public string type;
	
	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		cldr = GetComponent<Collider>();
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
