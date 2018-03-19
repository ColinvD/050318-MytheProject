using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Cloud))]
public class CloudCollision : MonoBehaviour {

	Cloud cloud;

	private void Awake()
	{
		cloud = GetComponent<Cloud>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D c)
	{
		cloud.move = false;
		cloud.curMoveSpeed = cloud.moveSpeed;
	}
}
