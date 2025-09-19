using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
	// Singleton
	public static FoodSpawner Instance;

	// Constants
	private int maxFood = 3;

	// Arrays
	[SerializeField] private Food[] foodTypes;
	[SerializeField] private Transform[] positions;

	// System vars
	private int activeFood;
	private float spawnTimer = 3;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(Instance);
		}
	}

	private void Update()
	{
		if(activeFood < maxFood && spawnTimer > 0)
		{
			spawnTimer -= Time.deltaTime;

			if(spawnTimer <= 0)
			{
				// Set the timer to a new random number
				spawnTimer = Random.Range(5, 8);

				// Spawn a random food at a random position
				int randFood = Random.Range(0, foodTypes.Length);
				Food food = foodTypes[randFood];

				int randTrans = Random.Range(0, positions.Length);
				Transform trans = positions[randTrans];


				SpawnFood(food, trans.position);
			}
		}
	}

	private void SpawnFood(Food food, Vector3 worldPos)
	{
		Instantiate(food, worldPos, Quaternion.identity);
		activeFood++;
	}

	public void OnFoodConsume()
	{
		activeFood--;
	}
}
