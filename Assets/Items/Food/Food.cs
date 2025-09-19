using UnityEngine;

public class Food : ItemBase
{
	[SerializeField] private float nutrition;

	protected override void OnPickup(PlayerStats playerStats)
	{
		base.OnPickup(playerStats);

		playerStats.AddNutrition(nutrition);

		// Tell the food manager that a peice of food has been freed
		FoodSpawner.Instance.OnFoodConsume();
	}
}
