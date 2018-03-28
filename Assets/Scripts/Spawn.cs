using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

	[Tooltip("The tag of the spawn positions.")]
	[SerializeField] private string spawnsTag = "Spawn";
	[Tooltip("The tag of the object(s) that needs to be spawned.")]
	[SerializeField] private string objectsTag = "Cloud";
	[Tooltip("The tag of the row container object.")]
	[SerializeField] private string rowContainerTag = "Rows";
	[Tooltip("How many seconds between each spawn.")]
	[SerializeField] private float spawnTime = 3;
	[Tooltip("How many seconds before the shield goes down.")]
	[SerializeField] private float shieldTime = 1;
	[SerializeField] private Sprite[] cloudSprites;

	// TODO: 

	public List<GameObject> spawned;
	public List<GameObject> notSpawned;
	public GameObject[][] rowsContent;
	public GameObject[] spawns;
	public int maxRowQuantity = 4;

	private GameObject[] objects;
	private GameObject rowContainer;

	// Use this for initialization
	void Start () {
		spawns = GameObject.FindGameObjectsWithTag(spawnsTag);
		objects = GameObject.FindGameObjectsWithTag(objectsTag);
		rowContainer = GameObject.FindGameObjectWithTag(rowContainerTag);
		rowsContent = new GameObject[rowContainer.transform.childCount][];
		spawned = new List<GameObject>();
		notSpawned = new List<GameObject>();

		InitArrList();
		StartCoroutine(SpawnCloud());
	}
	
	// Update is called once per frame
	void Update () {
	}

	public int RandomizeArrayIndex(GameObject[] array)
	{
		int randomIndex = 0;

		randomIndex = Random.Range(0, array.Length);

		//Debug.Log(array + " length = " + array.Length);

		return randomIndex;
	}

	public int RandomizeListIndex(List<GameObject> list)
	{
		int randomIndex = 0;

		randomIndex = Random.Range(0, list.Count-1);

		//Debug.Log(list + " count = " + list.Count);

		return randomIndex;
	}

	// Spawn Object based on given array 'spawns'
	public void SpawnObject(GameObject gameObject)
	{
		int randomIndex = 0;

		randomIndex = RandomizeArrayIndex(spawns);

		// Remove this if project has no clouds
		if (gameObject.tag == "Cloud")
		{
			Cloud cloud;
			cloud = gameObject.GetComponent<Cloud>();
			
			if (!cloud.move)
			{
				Debug.Log("first " + spawns[randomIndex]);
				Debug.Log(CheckEmptyRowIndex(rowsContent, CheckRow(spawns[randomIndex])));

				while (CheckEmptyRowIndex(rowsContent,CheckRow(spawns[randomIndex])) == 99)
				{
					Debug.Log("FULL");
					randomIndex = RandomizeArrayIndex(spawns);
					Debug.Log("second " + randomIndex);
				}

				//Debug.Log("third " + spawns[randomIndex]);

				gameObject.transform.position = spawns[randomIndex].transform.position;

				switch (spawns[randomIndex].transform.parent.name)
				{
					case "Right":
						cloud.direction = Cloud.DirOption.left;
						break;
					case "Left":
						cloud.direction = Cloud.DirOption.right;
						break;
					default:

						break;
				}

				cloud.move = true;
			}


			// TODO: FIX IF ROW IS FULL

			Debug.Log("Added " + cloud.name + " to row " + CheckRow(spawns[randomIndex]) + " at index "+ CheckEmptyRowIndex(rowsContent,CheckRow(spawns[randomIndex])));
			AddCloudTo(cloud.gameObject,rowsContent,CheckRow(spawns[randomIndex]));
		}
		else
		{
			gameObject.transform.position = spawns[randomIndex].transform.position;
		}
	}

	IEnumerator SpawnCloud()
	{
		int randomIndex = RandomizeListIndex(notSpawned);
		GameObject gameObject = notSpawned[randomIndex];
		Cloud cloud = gameObject.GetComponent<Cloud>();

		SpawnObject(gameObject);
		cloud.move = true;
		StartCoroutine(cloud.ShieldTimer(shieldTime));

		// Update lists to keep track of spawned objects
		spawned.Add(gameObject);
		notSpawned.Remove(gameObject);

		yield return new WaitForSeconds(spawnTime);
		StartCoroutine(SpawnCloud());
	}

	public int CheckRow(GameObject spawn)
	{
		int row = 0;
		string name = spawn.name;

		for (int i = 0; i < name.Length; i++)
		{
			if (name[i] == '1')
			{
				return 0;
			}
			else if (name[i] == '2')
			{
				return 1;
			}
			else if (name[i] == '3')
			{
				return 2;
			}
			else if (name[i] == '4')
			{
				return 3;
			}
			else if (name[i] == '5')
			{
				return 4;
			}
			else if (name[i] == '6')
			{
				return 5;
			}
			else if (name[i] == '7')
			{
				return 6;
			}
		}
		return row;
	}

	// Initialize arrays & lists
	public void InitArrList()
	{
		for (int i = 0; i < objects.Length; i++)
		{
			notSpawned.Add(objects[i]);
		}

		for (int i = 0; i < rowsContent.Length; i++)
		{
			rowsContent[i] = new GameObject[maxRowQuantity];
		}
	}

	public int CheckEmptyRowIndex(GameObject[][] array, int rowNumber)
	{
		int rowIndex = 0;
		int i;

		for (i = 0; i < array[rowNumber].Length; i++)
		{
			if (array[rowNumber][i] == null)
			{
				return rowIndex = i;
			}
		}

		//Debug.Log(i);
		//Debug.Log(array[rowNumber][i] + " FULL");
		rowIndex = 99;
		return rowIndex;
	}

	public void AddCloudTo(GameObject cloud, GameObject[][] array, int rowNumber)
	{
		int emptyIndex = CheckEmptyRowIndex(rowsContent, rowNumber);
		Debug.Log("row: " + rowNumber + " index: " + emptyIndex);
		array[rowNumber][emptyIndex] = cloud;
	}
}
