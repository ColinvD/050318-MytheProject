using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour {

	[SerializeField] private int curToGo = 30;
	[SerializeField] private Text count;

	public int CurToGO { get; set; }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		count.text = curToGo.ToString();
		if (curToGo < 1)
		{
			// win
		}
	}

	public void DecreaseBy(int i)
	{
		curToGo -= i;
	}

	public void InreaseBy(int i)
	{
		curToGo += i;
	}
}
