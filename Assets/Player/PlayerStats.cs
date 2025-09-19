using UnityEngine;

public class PlayerStats : MonoBehaviour
{
	private const float maxNutrition = 100f;

	// System

	private float nutrition;
	private float degredation = 3.3f;

	private void Awake()
	{
		nutrition = maxNutrition;
	}

	void Update()
    {
        if(nutrition > 0)
		{
			RemoveNutrition(Time.deltaTime * degredation);
		}
    }

	/// <summary>
	/// Sets nutrition value and clamps it
	/// </summary>
	public void SetNutrition(float value) 
	{
		nutrition = value;
		nutrition = Mathf.Clamp(nutrition, 0, maxNutrition);

		// Update nutrition text in HUD singleton
		HUDManager.Instance.SetNutritionText(nutrition);

		if (nutrition <= 0)
			HUDManager.Instance.DisplayStarvedText();
	}

	public void AddNutrition(float value) => SetNutrition(nutrition + value);

	public void RemoveNutrition(float value) => SetNutrition(nutrition - value);
}
