using System.Collections;
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
	private int cloudCount = 1;

	public int CloudCount
	{
		get
		{
			return cloudCount;
		}
	}

	Data data;
	Animator anim;
	SpriteRenderer sprRen;
	Sprite startSprite;
	BoxCollider2D boxCol;

	private void Awake()
	{
		data = FindObjectOfType<Data>();
		anim = GetComponent<Animator>();
		sprRen = GetComponent<SpriteRenderer>();
		boxCol = GetComponent<BoxCollider2D>();
	}
	
	void Start()
	{	
		// Debug
		moveSpeed = 2;
		decreaseTime = 5;
		shield = true;
		startSprite = sprRen.sprite;
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
		anim.Play(name, -1, 0);
		yield return new WaitForSeconds(waitTime);
		anim.enabled = false;
		boxCol.enabled = true;
		sprRen.sprite = startSprite;
	}

	public void ChangeProperties(Sprite cloudSprite, float cloudDamage, float cloudMoveSpeed)
	{
		sprRen.sprite = cloudSprite;
		startSprite = cloudSprite;
		damage = cloudDamage;
		moveSpeed = cloudMoveSpeed;
	}
}
