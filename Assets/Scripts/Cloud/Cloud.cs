﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {

	// TODO: make all variables getter & setter
	public float moveSpeed = 2;
	public enum DirOption { none, right, left };
	public DirOption direction;
	public bool move = false;
	public bool shield = true;
	public bool spawned = false;
	public float damage = 0.001f;
	public float decreaseTime = 10f;
	public int rowNumber;
	public int columnNumber;
	private int cloudCount = 1;

	private float explosionTime = 1f;
	[SerializeField] private bool idle = true;

	public float ExplosionTime
	{
		get
		{
			return explosionTime;
		}
	}
	public bool Idle
	{
		get
		{
			return idle;
		}
		set
		{
			idle = value;
		}
	}

	public int CloudCount
	{
		get
		{
			return cloudCount;
		}
	}

	public Animator anim;
	Data data;
	SpriteRenderer sprRen;
	Sprite startSprite;
	BoxCollider2D boxCol;
    CloudChecker checker;

	private void Awake()
	{
		data = FindObjectOfType<Data>();
		anim = GetComponent<Animator>();
		sprRen = GetComponent<SpriteRenderer>();
		boxCol = GetComponent<BoxCollider2D>();
        checker = FindObjectOfType<CloudChecker>();
	}
	
	void Start()
	{
		// Debug
		moveSpeed = 2;
		decreaseTime = 5;
		shield = true;
	}

	private void Update()
	{
		if (!idle)
		{
			StartCoroutine(PlayAnimation(WhichAnimation(sprRen.sprite), 0));
		}
	}

	public string CheckDir()
	{
		switch (direction)
		{
			case DirOption.right:
				return "right";
			case DirOption.left:
				return "left";
			default:
				return "";
		}
	}

	public void MoveTo(Vector3 position)
	{
		transform.position = position;
	}

	public void ChangeProperties(Sprite cloudSprite, float cloudDamage, float cloudMoveSpeed)
	{
		sprRen.sprite = cloudSprite;
		startSprite = cloudSprite;
		damage = cloudDamage;
		moveSpeed = cloudMoveSpeed;
	}

	public IEnumerator ShieldTimer(float shieldTime)
	{
		shield = true;
		yield return new WaitForSeconds(shieldTime);
		shield = false;
	}

	// TODO: put this function inside the data class
	public IEnumerator DecreasePatience(float amount)
	{
		data.currentPatience -= amount;

		yield return new WaitForSeconds(decreaseTime);
		if (spawned)
		{
			StartCoroutine(DecreasePatience(amount));
		}
	}

	public IEnumerator PlayAnimation(string name, float waitTime)
	{
		if (name == "Cloud Explosion")
		{
			anim.enabled = true;
			boxCol.enabled = false;
			anim.Play(name, -1, 0);
			yield return new WaitForSeconds(waitTime);
			boxCol.enabled = true;
			sprRen.sprite = startSprite;
			anim.enabled = false;
		}
		else if (name == "Cloud Attack")
		{

		}
		else
		{
			anim.enabled = true;
			anim.Play(name, -1, 0);
			idle = true;
		}
        
		if (!spawned)
		{
			anim.enabled = false;
		}
        else if (spawned)
        {
            checker.HasSeen(GetCloudType(sprRen.sprite));
        }
	}

	public string GetCloudColor(Sprite cloudSprite)
	{
		string spriteName = cloudSprite.name;
		string color = "";
		for (int i = 0; i < spriteName.Length; i++)
		{
			if (spriteName[i] == ' ')
			{
				for (int j = i+1; j < spriteName.Length; j++)
				{
					color += spriteName[j];
				}
				return color;
			}
		}
		return "Type: Not found";
	}

	public string GetCloudType(Sprite cloudSprite)
	{
		string spriteName = cloudSprite.name;
		string typeName = "";
		for (int i = 0; i < spriteName.Length; i++)
		{
			if (spriteName[i] == ' ')
			{
				for (int j = 0; j < i; j++)
				{
					typeName += spriteName[j];
				}
				return typeName;
			}
		}
		return "Type: Not found";
	}

	public string SetCloudType(Sprite[] cloudForms, int randomIndex)
	{
		string typeName = "";

		typeName = GetCloudType(cloudForms[randomIndex]);

		// TODO: Set first letter to uppercase

		return typeName;
	}

	// Checks which color and type the cloud is, so it can give the right idle animation name
	public string WhichAnimation(Sprite cloudSprite)
	{
		string name = "";
		string type = "";
		string color = "";
		Sprite sprite = sprRen.sprite;

		type = GetCloudType(sprite);
		color = GetCloudColor(sprite);

		name = type + " " + color + " idle";

		return name;
	}
}
