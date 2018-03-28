using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Cloud))]
public class CloudCollision : MonoBehaviour {

	[SerializeField] private float shieldTime = 0.2f;

	Cloud cloud;
	Spawn spawn;

	private void Awake()
	{
		cloud = GetComponent<Cloud>();
		spawn = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawn>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D c)
	{
		
		if ((c.tag == "Cloud" || c.tag == "Spawn") && !cloud.shield) cloud.move = false;
		if (c.tag == "Projectile")
		{
			if (c.GetComponent<SpriteRenderer>().sprite.name == GetComponent<SpriteRenderer>().sprite.name)
			{
				spawn.spawned.Remove(gameObject);
				spawn.notSpawned.Add(gameObject);
				cloud.MoveTo(spawn.spawns[spawn.RandomizeArrayIndex(spawn.spawns)].transform.position);
			}
			Destroy(c.gameObject);
			c.GetComponent<Projectile>().OnDeath();
		}
	}

	private void OnTriggerStay2D(Collider2D c)
	{
		//cloud.shield = true;
	}


	private void OnTriggerExit2D(Collider2D c)
	{
		cloud.ShieldTimer(shieldTime);
	}
}
