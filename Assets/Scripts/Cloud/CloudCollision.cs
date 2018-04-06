using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Cloud))]
public class CloudCollision : MonoBehaviour {

	[SerializeField] private float shieldTime = 0.2f;

	Cloud cloud;
	Spawn spawn;
	Data data;

	private void Awake()
	{
		cloud = GetComponent<Cloud>();
		spawn = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawn>();
		data = FindObjectOfType<Data>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D c)
	{
		if (c.transform.childCount > 0)
		{
			if (c.transform.childCount == 1)
			{
				if (c.gameObject.transform.GetChild(0).tag == "Cloud" && !cloud.shield)
				{
					cloud.move = false;
					cloud.spawned = true;
					StartCoroutine(cloud.DecreasePatience(cloud.damage));
				}
			}
			else if (c.transform.childCount == 2)
			{
				if (c.gameObject.transform.GetChild(1).tag == "Projectile")
				{
					if (c.tag == tag)
					{
						//spawn.spawned.Remove(gameObject);
						//index in row = System.Array.IndexOf(spawn.rowsContent[cloud.rowNumber], cloud.gameObject);
						spawn.rowsContent[cloud.rowNumber][System.Array.IndexOf(spawn.rowsContent[cloud.rowNumber], cloud.gameObject)] = null;
						data.IncreasePatience(data.increaseValue);
						spawn.notSpawned.Add(gameObject);
						cloud.spawned = false;
						cloud.MoveTo(spawn.spawns[spawn.RandomizeArrayIndex(spawn.spawns)].transform.position);
					}
				}
			}
		}
		else if (c.tag == "Spawn" && !cloud.shield)
		{
			cloud.move = false;
			cloud.spawned = true;
			StartCoroutine(cloud.DecreasePatience(cloud.damage));
		}
	}

	private void OnTriggerStay2D(Collider2D c)
	{
	}


	private void OnTriggerExit2D(Collider2D c)
	{
		cloud.ShieldTimer(shieldTime);
	}
}
