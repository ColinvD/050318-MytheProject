using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {

	public float moveSpeed = 1;
	public enum DirOption { none, right, left };
	public DirOption direction;
	public bool move = false;
	public bool shield = true;
	public bool spawned = false;
	public float damage = 0.1f;
	public float decreaseTime = 5;
	public int rowNumber;

	DebugManager debug;
	Data data;
	Animator anim;
	SpriteRenderer sprRen;
	Sprite startSprite;
	BoxCollider2D boxCol;

	// public string color;

	//private GameObject[] spawnPositions;

	// Use this for initialization
	void Start() {
		shield = true;
		debug = FindObjectOfType<DebugManager>();
		data = FindObjectOfType<Data>();
		anim = GetComponent<Animator>();
		sprRen = GetComponent<SpriteRenderer>();
		boxCol = GetComponent<BoxCollider2D>();
		decreaseTime = 5;

		startSprite = sprRen.sprite;
	}

	// Update is called once per frame
	void Update() {
		moveSpeed = debug.cloudMoveSpeed;
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
		anim.enabled = true;
		boxCol.enabled = false;
		anim.Play(name);
		yield return new WaitForSeconds(waitTime);
		anim.enabled = false;
		boxCol.enabled = true;
		sprRen.sprite = startSprite;
	}
}
