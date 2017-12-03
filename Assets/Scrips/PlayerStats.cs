using UnityEngine;

public class PlayerStats : MonoBehaviour
{
	public int xpPerLevel = 100;
	public float money = 5000f;
	public long xp = 0;
	public int level = 0;

	private void Update()
	{
		level = (int)(xp / xpPerLevel);
	}
}
