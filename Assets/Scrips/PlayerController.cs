using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
	private PlayerMotor motor;
	private bool hasPickup = false;
	private Pickup pickup;

	public Camera cam;
	public GameObject holder;
	public float speed = 5f;
	public float lookSense = 3f;
	public float throwForce = 100f;


	private void Start ()
	{
		motor = GetComponent<PlayerMotor>();
	}
	
	private void Update ()
	{
		#region movement

		// Calculate movement
		float xMov = Input.GetAxis("Horizontal");
		float yMov = Input.GetAxis("Vertical");
		
		Vector3 horizontalMovement = transform.right * xMov;
		Vector3 verticalMovement = transform.forward * yMov;

		// Final movement vector
		Vector3 velocity = (horizontalMovement + verticalMovement) * speed;

		// Apply movement
		motor.Move(velocity);

		#endregion

		#region rotation

		// Calculate rotation
		float yRot = Input.GetAxisRaw("Mouse X");
		Vector3 rotation = new Vector3(0f, yRot, 0f) * lookSense;
		motor.Rotate(rotation);

		float xRot = Input.GetAxisRaw("Mouse Y");
		float cameraRotationX =  xRot * lookSense;
		motor.RotateCamera(cameraRotationX);

		#endregion
	
		#region pickup

		if (!hasPickup)
		{
			if (cam != null)
			{
				// Check if player is pointing to a pickup
				RaycastHit hit;
				if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 2f) && !hasPickup)
				{
					pickup = hit.collider.GetComponent<Pickup>();

					if (pickup != null)
					{
						// Check if player wants to pick the pickup
						if (Input.GetKeyDown(KeyCode.E))
						{
							// Pick pickup
							hasPickup = true;
							
							if (holder != null)
							{
								pickup.Pick(holder.transform);
							}
						}
					}
				}
			}
		}
		else
		{
			// Check if player wants to drop the pickup
			if (Input.GetKeyDown(KeyCode.E))
			{
				// Drop pickup
				hasPickup = false;
				pickup.Throw(throwForce);
			}
		}

		#endregion
	}
}
