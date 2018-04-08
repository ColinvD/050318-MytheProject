using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

	[Tooltip("The tag of the spawn positions.")]
	[SerializeField] private string spawnsTag = "Spawn";
	//[Tooltip("The tag of the object(s) that needs to be spawned.")]
	//[SerializeField] private string objectsTag = "Cloud";
	[Tooltip("The tag of the row container object.")]
	[SerializeField] private string rowContainerTag = "Rows";
	[Tooltip("How many seconds between each spawn.")]
	[SerializeField] private float spawnTime = 3;
	[Tooltip("How many seconds before the shield goes down.")]
	[SerializeField] private float shieldTime = 1;

	public List<GameObject> spawned;
	public List<GameObject> notSpawned;
	public GameObject[][] rowsContent;
	public GameObject[] spawns;
	public int maxRowQuantity = 4;
	public bool spawn;

	private List<GameObject> objects;
	private GameObject rowContainer;
	private int test = 1;
	private int row;

	// Use this for initialization
	void Start () {
		spawns = GameObject.FindGameObjectsWithTag(spawnsTag);
		rowContainer = GameObject.FindGameObjectWithTag(rowContainerTag);
		rowsContent = new GameObject[rowContainer.transform.childCount][];
		spawned = new List<GameObject>();
		notSpawned = new List<GameObject>();
		objects = new List<GameObject>();
		
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

		//for (int i = 0; i < list.Count; i++)
		//{
		//	Debug.Log(list[i].name + " at index " + list.IndexOf(list[i]));
		//}

		//Debug.LogWarning("chosen index " + randomIndex);

		return randomIndex;
	}

	// Spawn Object based on given array 'spawns'
	public void SpawnObject(GameObject gameObject)
	{
		int randomIndex = 0;
		
		if (gameObject.transform.GetChild(0).tag == "Cloud")
		{
			Cloud cloud;
			cloud = gameObject.GetComponent<Cloud>();

			if (!cloud.move)
			{
				do
				{
					randomIndex = RandomizeArrayIndex(spawns);
				} while (CheckEmptyRowIndex(rowsContent, CheckRow(spawns[randomIndex])) == 99);

				cloud.rowNumber = row;

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

				if (!IsListEmpty(notSpawned))
				{
					AddCloudTo(cloud.gameObject, rowsContent, CheckRow(spawns[randomIndex]));
				}
				else
				{
					Debug.Log("Empty");
				}
			}
		}
		else
		{
			gameObject.transform.position = spawns[randomIndex].transform.position;
		}
	}

	public IEnumerator SpawnCloud()
	{
		try
		{
			int randomIndex = RandomizeListIndex(notSpawned);
			GameObject gameObject = notSpawned[randomIndex];
			Cloud cloud = gameObject.GetComponent<Cloud>();
			
			SpawnObject(gameObject);
			cloud.move = true;
			StartCoroutine(cloud.ShieldTimer(shieldTime));

			// Update lists to keep track of spawned objects
			//spawned.Add(gameObject);
			notSpawned.Remove(gameObject);
		}
		catch
		{
			//Debug.LogWarning("No clouds to spawn");
		}
		
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
	
	public void InitArrList()
	{
		// Initializes all clouds into 'objects[]'
		for (int i = 0; i < rowContainer.transform.childCount; i++)
		{
			for (int j = 0; j < rowContainer.transform.GetChild(i).childCount; j++)
			{
				GameObject cloud = rowContainer.transform.GetChild(i).transform.GetChild(j).gameObject;
				notSpawned.Add(cloud);
			}
		}

		// Initializes all clouds into 'notSpawned[]'
		for (int i = 0; i < objects.Count; i++)	notSpawned.Add(objects[i]);

		// Initializes all rows into 'rowsContent[]'
		for (int i = 0; i < rowsContent.Length; i++)
		{
			rowsContent[i] = new GameObject[maxRowQuantity];
		}
	}

	public int CheckEmptyRowIndex(GameObject[][] array, int rowNumber)
	{
		int i;
		int rowIndex = 0;

		// Checks if there is empty place on a row
		for (i = 0; i < array[rowNumber].Length; i++)
		{
			if (array[rowNumber][i] == null)
			{
				row = rowNumber;
				return rowIndex = i;
			}
		}
		
		if (!IsListEmpty(notSpawned))
		{
			rowIndex = 99;
			//Debug.Log("Not empty " + test);
			test++;
		}
		else
		{
			Debug.Log("Empty");
			rowIndex = 100;
		}

		//Debug.Log(rowNumber + " FULL");
		return rowIndex;
	}

	public bool IsListEmpty(List<GameObject> list)
	{/*
		// Checks if there is a empty row
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i] != null)
			{
				return false;
			}
		}

		return true;
		*/
		return list.Count > 0 ? false : true;
	}

	public void AddCloudTo(GameObject cloud, GameObject[][] array, int rowNumber)
	{
		int emptyIndex = CheckEmptyRowIndex(rowsContent, rowNumber);
		//Debug.Log("row: " + rowNumber + " index: " + emptyIndex);
		array[rowNumber][emptyIndex] = cloud;
	}
}
