using UnityEngine;
using UnityEditor;

public class Deposit : MonoBehaviour
{
	public GameObject correctObject;

	void OnTriggerEnter(Collider other)
	{
		if (correctObject != null)
		{
			Pickup pickup = other.GetComponent<Pickup>();
			Pickup correctPickup = correctObject.GetComponent<Pickup>();
			
			if (pickup != null && correctPickup != null)
			{
				if (pickup.type != null && correctPickup.type != null)
				{
					if (pickup.type == correctPickup.type)
					{
						// Add money and xp to player
					}
					else
					{
						// Remove money from player
					}
				}
			}
		}
	}
}
