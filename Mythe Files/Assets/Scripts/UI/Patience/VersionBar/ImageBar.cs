using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageBar : MonoBehaviour {

    public const int maxPatience = 100;
    public Data data;
    public RectTransform patiencebar;
    public bool testing;
    public float amount = -1;
    public float nextUpdate = 1;

	// Use this for initialization
	void Start () {
        data = GameObject.FindGameObjectWithTag("Data").GetComponent<Data>();
        if (data.currentPatience <= 0)
        {
            data.currentPatience = maxPatience;
        }
	}

    public void add(float amount)
    {
        data.currentPatience += amount;
        patiencebar.sizeDelta = new Vector2(data.currentPatience * 1, patiencebar.sizeDelta.y);
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
	void Update () {
        if (testing)
        {
            StartCoroutine("CountDown");
            testing = !testing;
        }
	}
}
