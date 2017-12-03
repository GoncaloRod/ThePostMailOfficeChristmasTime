using UnityEngine;
using UnityEditor;

public class Deposit : MonoBehaviour
{
	public GameObject correctObject;
	public GameObject player;

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
						if (player != null)
						{
							// Play correct sound

							// Add money and xp to player
							PlayerStats stats = player.GetComponent<PlayerStats>();

							if (stats != null)
							{
								stats.money += pickup.moneyIncrement;
								stats.xp += pickup.xpIncrement;
							}
						}
					}
					else
					{
						if (player != null)
						{
							// Play incorrect sound

							// Remove money from player
							PlayerStats stats = player.GetComponent<PlayerStats>();

							if (stats != null)
							{
								stats.money -= pickup.moneyDecrement;
							}
						}
					}
				}
			}
		}

		// Destroy pickup
		Destroy(other.gameObject);
	}
}
