using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatienceImage : MonoBehaviour
{

    [SerializeField]
    private List<GameObject> images;
    [SerializeField]
    private int addAmount = -1;
    private int testInt = 0;
    public bool startBool = false;

    // Use this for initialization
    void Start()
    {
        StartCoroutine("CountDown");
    }

    // Update is called once per frame
    void Update()
    {
        if (startBool)
        {
            Add(addAmount);
            startBool = !startBool;
        }
    }

    private IEnumerator CountDown()
    {
        while (testInt < 21)
        {
            for (int i = 0; i < images.Count; i++)
            {
                if (images[i].active != false)
                {
                    images[i].SetActive(false);
                }

                if (i == testInt)
                {
                    images[i].SetActive(true);
                }
            }
            yield return new WaitForSeconds(1);
            testInt++;
        }
    }

    private void Add(int amount)
    {
        testInt += amount;
    }
}
