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
	[Header("Normal cloud damage")]
	[SerializeField] private float normDamage;
	[Header("Rain cloud damage")]
	[SerializeField] private float rainDamage;
	[Header("Thunder cloud damage")]
	[SerializeField] private float thunDamage;
	[SerializeField] private int level;

	public List<GameObject> notSpawned;
	public GameObject[][] rowsContent;
	public GameObject[] spawns;
	public int maxRowQuantity = 4;
	public bool spawn;

	private List<GameObject> objects;
	private GameObject rowContainer;
	private Sprite cloudForm;
	private int row;
	private Sprite[] redCloudForms;
	private Sprite[] blueCloudForms;
	private Sprite[] pinkCloudForms;
	private Sprite[] yellowCloudForms;
	private SpriteHolder buffer;

	public Sprite[] RedCloudForms { get; set; }
	public Sprite[] BlueCloudForms { get; set; }
	public Sprite[] PinkCloudForms { get; set; }
	public Sprite[] YellowCloudForms { get; set; }

	void Start()
	{
		spawns = GameObject.FindGameObjectsWithTag(spawnsTag);
		rowContainer = GameObject.FindGameObjectWithTag(rowContainerTag);
		rowsContent = new GameObject[rowContainer.transform.childCount][];
		notSpawned = new List<GameObject>();
		objects = new List<GameObject>();
		buffer = Resources.Load<SpriteHolder>("Script Objects/Level " + level.ToString() + " Clouds");

		InitArrList();
		InitClouds(buffer);
		StartCoroutine(SpawnCloud());
	}

	public int RandomizeArrayIndex<T>(T[] array)
	{
		int randomIndex = 0;
		
		randomIndex = Random.Range(0, array.Length);

		return randomIndex;
	}

	public int RandomizeListIndex<T>(List<T> list)
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

	// Spawns an object on spawn locations of the array 'spawns'
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
			}
		}
		else
		{
			gameObject.transform.position = spawns[randomIndex].transform.position;
		}
	}

	// Spawns a cloud randomly chosen from the 'notSpawned' list
	public IEnumerator SpawnCloud()
	{
		int randomIndex = RandomizeListIndex(notSpawned);
		GameObject gameObject = notSpawned[randomIndex];
		Cloud cloud = gameObject.GetComponent<Cloud>();

		randomIndex = RandomizeArrayIndex(GetArrayColor(cloud));
		InitCloudProperties(cloud, cloud.SetCloudType(GetArrayColor(cloud), randomIndex), randomIndex, GetArrayColor(cloud));

		SpawnObject(gameObject);
		cloud.spawned = true;
		cloud.move = true;
		cloud.Idle = false;
		StartCoroutine(cloud.ShieldTimer(shieldTime));

		// Update lists to keep track of spawned objects
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
		array[rowNumber][emptyIndex] = cloud;
	}

	private Sprite[] GetArrayColor(Cloud cloud)
	{
		Sprite[] array = null;
		switch (cloud.tag)
		{
			case "Red":
				array = redCloudForms;
				break;
			case "Blue":
				array = blueCloudForms;
				break;
			case "Pink":
				array = pinkCloudForms;
				break;
			case "Yellow":
				array = yellowCloudForms;
				break;
		}

		return array;
	}

	private void InitCloudProperties(Cloud cloud, string cloudType, int index, Sprite[] array)
	{	
		switch (cloudType)
		{
			case "gewoon":
				cloud.ChangeProperties(array[index], normDamage, cloud.moveSpeed);
				break;
			case "regen":
				cloud.ChangeProperties(array[index], rainDamage, cloud.moveSpeed);
				break;
			case "donder":
				cloud.ChangeProperties(array[index], thunDamage, cloud.moveSpeed);
				break;
			default:
				print("Type: not found");
				break;
		}
	}

	public void InitClouds(SpriteHolder buffer)
	{
		redCloudForms = buffer.redCloudForms;
		blueCloudForms = buffer.blueCloudForms;
		pinkCloudForms = buffer.pinkCloudForms;
		yellowCloudForms = buffer.yellowCloudForms;
	}

	public void InitArrList()
	{
		// Initializes all clouds into 'objects[]'
		for (int i = 0; i < rowContainer.transform.childCount; i++)
		{
			for (int j = 0; j < rowContainer.transform.GetChild(i).childCount; j++)
			{
				GameObject cloud = rowContainer.transform.GetChild(i).transform.GetChild(j).gameObject;
				objects.Add(cloud);
			}
		}

		// Initializes all clouds into 'notSpawned[]'
		for (int i = 0; i < objects.Count; i++) notSpawned.Add(objects[i]);

		// Initializes all rows into 'rowsContent[]'
		for (int i = 0; i < rowsContent.Length; i++)
		{
			rowsContent[i] = new GameObject[maxRowQuantity];
		}
	}

}
