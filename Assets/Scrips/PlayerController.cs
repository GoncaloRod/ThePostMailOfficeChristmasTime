using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
	private PlayerMotor motor;

	public float speed = 5f;
	public float lookSense = 3f;


	private void Start ()
	{
		motor = GetComponent<PlayerMotor>();
	}
	
	private void Update ()
	{
		// Calculate movement
		float xMov = Input.GetAxis("Horizontal");
		float yMov = Input.GetAxis("Vertical");
		
		Vector3 horizontalMovement = transform.right * xMov;
		Vector3 verticalMovement = transform.forward * yMov;

		// Final movement vector
		Vector3 velocity = (horizontalMovement + verticalMovement) * speed;

		// Apply movement
		motor.Move(velocity);

		// Calculate rotation
		float yRot = Input.GetAxisRaw("Mouse X");
		Vector3 rotation = new Vector3(0f, yRot, 0f) * lookSense;
		motor.Rotate(rotation);
	}
}
