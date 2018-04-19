using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Cloud))]
public class CloudCollision : MonoBehaviour {

	[SerializeField] private float shieldTime = 0.2f;

	Cloud cloud;
	Spawn spawn;
	Data data;
	Counter count;
	Patience patience;

	private void Awake()
	{
		cloud = GetComponent<Cloud>();
		spawn = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawn>();
		data = FindObjectOfType<Data>();
		count = FindObjectOfType<Counter>();
		patience = FindObjectOfType<Patience>();
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
					//StartCoroutine(cloud.DecreasePatience(cloud.damage));
					patience.IncreaseTotalDamage(cloud.damage);

				}
			}
			else if (c.transform.childCount == 2)
			{
				if (cloud.spawned)
				{
					if (c.gameObject.transform.GetChild(1).tag == "Projectile")
					{
						if (c.tag == tag)
						{
							StartCoroutine(Die(cloud.ExplosionTime));
						}
					}
				}
			}
		}
		else if (c.tag == "Spawn" && !cloud.shield)
		{
			cloud.move = false;
			//StartCoroutine(cloud.DecreasePatience(cloud.damage));
			patience.IncreaseTotalDamage(cloud.damage);
		}
	}

	private void OnTriggerExit2D(Collider2D c)
	{
		cloud.ShieldTimer(shieldTime);
	}

	IEnumerator Die(float waitTime)
	{
		cloud.move = false;
		patience.DecreaseTotalDamage(cloud.damage);
		count.DecreaseBy(cloud.CloudCount);
		StartCoroutine(cloud.PlayAnimation("Cloud Explosion", waitTime));
		
		spawn.rowsContent[cloud.rowNumber][System.Array.IndexOf(spawn.rowsContent[cloud.rowNumber], cloud.gameObject)] = null;

		data.IncreasePatience(data.increaseValue);
		spawn.notSpawned.Add(gameObject);
		cloud.spawned = false;
		yield return new WaitForSeconds(waitTime);
		cloud.MoveTo(spawn.spawns[spawn.RandomizeArrayIndex(spawn.spawns)].transform.position);
	}
}
