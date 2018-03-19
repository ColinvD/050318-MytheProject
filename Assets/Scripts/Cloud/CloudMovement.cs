using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Cloud))]
public class CloudMovement : MonoBehaviour {

	Cloud cloud;

	private void Awake()
	{
		cloud = GetComponent<Cloud>();
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (cloud.move)
		{
			MoveHorizontal(cloud.CheckDir(), cloud.moveSpeed);
		}
	}

	public void MoveHorizontal(string direction, float moveSpeed)
	{
		switch(direction)
		{
			case "right":
				transform.position += transform.right * Time.deltaTime * moveSpeed;
				break;

			case "left":
				transform.position -= transform.right * Time.deltaTime * moveSpeed;
				break;
			default:
				//Debug.LogError("No direction");
				break;
		}
	}
}
