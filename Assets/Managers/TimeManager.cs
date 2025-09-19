using UnityEngine;
using System;

public class TimeManager : MonoBehaviour
{
	public float GetTimeOfDayFraction()
	{
		DateTime currentTime = DateTime.Now;
		float fractionOfDay = currentTime.Hour / 24f + currentTime.Minute / 1440f;
		return fractionOfDay;
	}

	void Update()
	{
		// Example: Print the current time of day as a fraction
		Debug.Log("Time of Day (fraction): " + GetTimeOfDayFraction());
	}
}