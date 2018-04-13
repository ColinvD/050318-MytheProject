
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageBar : MonoBehaviour
{

	//private float beginSizeX;
	//private float beginSizeY;
	public const int maxPatience = 100;
	public Data data;
	//public RectTransform patiencebar;
	public bool testing = true;
	public float amount = -1;
	public float nextUpdate = 1;
	public Image bar;

	// Use this for initialization
	void Start()
	{
		//beginSizeX = patiencebar.sizeDelta.x;
		//beginSizeY = patiencebar.sizeDelta.y;
		data = FindObjectOfType<Data>();
		if (data.currentPatience <= 0)
		{
			data.currentPatience = maxPatience;
		}
	}

	public void add(float amount)
	{
		data.currentPatience += amount;
		if (data.currentPatience > maxPatience)
		{
			data.currentPatience = maxPatience;
		}
		bar.fillAmount = data.currentPatience / maxPatience;
		//patiencebar.sizeDelta = new Vector2(data.currentPatience * beginSizeX / maxPatience, beginSizeY);
	}

	public IEnumerator CountDown()
	{
		while (data.currentPatience > 0)
		{
			add(amount);
			yield return new WaitForSeconds(nextUpdate);
		}
	}

	// Update is called once per frame
	void Update()
	{
		if (testing)
		{
			StartCoroutine("CountDown");
			testing = !testing;
		}
	}
}