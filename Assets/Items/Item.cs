using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			OnPickup(other.GetComponent<PlayerStats>());
		}
	}

	/// <summary>
	/// Each item type should implement its own solution
	/// </summary>
	protected virtual void OnPickup(PlayerStats playerStats)
	{
		Destroy(gameObject);
	}
}
