using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

	[Tooltip("The tag of the spawn positions.")]
	[SerializeField] private string spawnsTag = "Spawn";
	[Tooltip("The tag of the object(s) that needs to be spawned.")]
	[SerializeField] private string objectsTag = "Cloud";

	private GameObject[] objects;
	private GameObject[] spawns;

	// Use this for initialization
	void Start () {
		spawns = GameObject.FindGameObjectsWithTag(spawnsTag);
		objects = GameObject.FindGameObjectsWithTag(objectsTag);

		/*for (int i = 0; i < spawns.Length-1; i ++)
		{
			Debug.Log("Spawn position: " + spawns[i].transform.localPosition);
		}

		for (int i = 0; i < objects.Length-1; i++)
		{
			Debug.Log("Objects: " + objects[i]);
		}*/
	}
	
	// Update is called once per frame
	void Update () {
		SpawnObject(objects[RandomizeIndex(objects)]);
		//Debug.Log(RandomizeIndex(objects));
	}

	public int RandomizeIndex(GameObject[] array)
	{
		int randomIndex = 0;

		randomIndex = Random.Range(0, array.Length);

		return randomIndex;
	}

	// Spawn Object based on given array 'spawns'
	public void SpawnObject(GameObject gameObject)
	{
		gameObject.transform.position = spawns[RandomizeIndex(spawns)].transform.position;
	}
}
