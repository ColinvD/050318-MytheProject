using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {

	public float moveSpeed = 1;
	public enum DirOption { none, right, left };
	public DirOption direction;
	public bool move = false;
	public bool shield = true;

	DebugManager debug;

	// public string color;

	//private GameObject[] spawnPositions;

	// Use this for initialization
	void Start() {
		shield = true;

		debug = GameObject.FindGameObjectWithTag("Debug").GetComponent<DebugManager>();
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
		yield return new WaitForSeconds(shieldTime);
		shield = false;
	}

}
