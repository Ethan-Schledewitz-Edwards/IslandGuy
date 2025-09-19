using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
	public static HUDManager Instance;

	[SerializeField] private TextMeshProUGUI nutritionText;
	[SerializeField] private GameObject starvedText;


	// System vars
	private float closeTimer;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(Instance);
		}

		starvedText.SetActive(false);
	}

	private void Update()
	{
		if (closeTimer > 0)
		{
			closeTimer -= Time.deltaTime;

			// Close game once timer reaches zero
			if (closeTimer <= 0)
				Application.Quit();
		}
	}

	public void SetNutritionText(float value)
	{
		// Set text to floored value 
		nutritionText.text = $"{Mathf.FloorToInt(value)}";
	}

	public void DisplayStarvedText()
	{
		starvedText.SetActive(true);

		nutritionText.gameObject.SetActive(false);

		// Start application quit timer
		closeTimer = 5;
	}
}
