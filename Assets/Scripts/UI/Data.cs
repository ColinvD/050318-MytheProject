using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour {

    public float currentPatience = 100;
	public int increaseValue = 10;

	private void Update()
	{
		if (currentPatience < 0) currentPatience = 0;
	}

	public void IncreasePatience(int amount)
	{
		currentPatience += amount;
	}
}
