using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {

	public float moveSpeed = 1;
	public enum DirOption { none, right, left };
	public DirOption direction;
	public bool move = false;
	public bool shield = true;
	public bool spawned = false;
	public int damage = 1;
	public float decreaseTime = 2;

	DebugManager debug;
	Data data;

	// public string color;

	//private GameObject[] spawnPositions;

	// Use this for initialization
	void Start() {
		shield = true;
		debug = FindObjectOfType<DebugManager>();
		data = FindObjectOfType<Data>();
		decreaseTime = 5;
	}

	// Update is called once per frame
	void Update() {
		moveSpeed = debug.cloudMoveSpeed;
	}

	public string CheckDir()
	{
		switch (direction)
		{
			case DirOption.right:
				return "right";
			case DirOption.left:
				return "left";
			default:
				return "";
		}
	}

	public void MoveTo(Vector3 position)
	{
		transform.position = position;
	}

	public IEnumerator ShieldTimer(float shieldTime)
	{
		shield = true;
		yield return new WaitForSeconds(shieldTime);
		shield = false;
	}

	public IEnumerator DecreasePatience(int amount)
	{
		while (spawned)
		{
			//Debug.Log("Decrease");
			data.currentPatience -= amount;
			yield return new WaitForSeconds(decreaseTime);
			StartCoroutine(DecreasePatience(amount));
		}
		/*
		Debug.Log("Decrease");
		data.currentPatience -= amount;
		yield return new WaitForSeconds(decreaseTime);
		StartCoroutine(DecreasePatience(amount));*/
	}
}
