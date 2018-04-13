using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patience : MonoBehaviour {

	[SerializeField] private float maxDamage;
	[SerializeField] private float decreaseTime = 3f;
	[SerializeField] private float divider = 10f;

	private float totalDamage;
	private Data data;

	public float TotalDamage
	{
		get
		{
			return totalDamage;
		}
		set
		{
			totalDamage = value;
		}
	}

	private void Awake()
	{
		data = FindObjectOfType<Data>();
	}

	// Use this for initialization
	void Start() {
		totalDamage = 0;
		StartCoroutine(DecreasePatience());
	}

	// Update is called once per frame
	void Update() {

	}

	IEnumerator DecreasePatience()
	{
		Debug.Log("Decreased by " + totalDamage / divider);
		data.currentPatience -= totalDamage / divider;
		yield return new WaitForSeconds(decreaseTime);
		StartCoroutine(DecreasePatience());
	}

	public void IncreaseTotalDamage(float i)
	{
		totalDamage += i;
		if (totalDamage > maxDamage) totalDamage = maxDamage;
	}

	public void DecreaseTotalDamage(float i)
	{
		totalDamage -= i;
		if (totalDamage < 0) totalDamage = 0;
	}
}
