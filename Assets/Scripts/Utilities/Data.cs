using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour {

    public float currentPatience = 100;
	public int increaseValue = 5;
	[SerializeField] private GameObject losePanel;

	private void Update()
	{
		if (currentPatience < 0)
		{
			currentPatience = 0;
			losePanel.SetActive(true);
			FindObjectOfType<TimeManagement>().ChangeTime(0);
		}
	}

	public void IncreasePatience(int amount)
	{
		currentPatience += amount;
	}
}
