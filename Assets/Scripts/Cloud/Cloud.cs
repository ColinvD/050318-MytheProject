using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {

	public float moveSpeed = 1;
	public float curMoveSpeed;
	public enum DirOption { none, right, left };
	public DirOption direction;
	public bool move = true;

	// public string color;

	//private GameObject[] spawnPositions;

	// Use this for initialization
	void Start() {
	}

	// Update is called once per frame
	void Update() {
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

	public void SetSpawnPos(int rowNumber, string side)
	{
		switch (side)
		{
			case "left":

				break;
			case "right":

				break;
			default:
				side = "left";
				break;
		}
	}

	private int CheckRowNum(int rowNumber)
	{
		switch(rowNumber)
		{
			case 1:
				
				break;
			case 2:

				break;
			case 3:

				break;
			case 4:

				break;
			case 5:

				break;
			case 6:

				break;
			case 7:

				break;
		}
		return rowNumber;
	}

	public void GoTo(Vector3 position)
	{
		move = false;
		transform.position = position;
	}
}
