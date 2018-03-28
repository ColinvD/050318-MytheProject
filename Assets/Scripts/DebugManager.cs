using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugManager : MonoBehaviour {

	public Spawn spawn;
	public float cloudMoveSpeed = 1;

	//GameObject[] clouds;

	private void Awake()
	{
		//clouds = GameObject.FindGameObjectsWithTag("Cloud");
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.R))
		{
			for (int i = 0; i < spawn.notSpawned.Count-1; i++)
			{
				Debug.Log(spawn.notSpawned[i]);
			}
		}
	}
}
