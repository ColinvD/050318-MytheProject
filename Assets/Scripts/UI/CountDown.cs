using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour {

    public float temp = 1f;
    public int temp2 = 10;

    public void CountingDown()
    {
        StartCoroutine(CountingDown(temp,temp2));
    }

    private IEnumerator CountingDown(float waitTime, int seconds)
    {
        while (seconds > 0)
        {
            seconds--;
            //other function
            yield return new WaitForSeconds(waitTime);
        }
    }

    /*
    private int seconds = 120;
    public delegate void Testing();
    public Testing test;

    private void Start()
    {
        test = log;
        DownCounting();
    }

    public void DownCounting()
    {
        StartCoroutine(CountingDown(1f));
        StartCoroutine(CountingDown2(0.5f, 3, "werkt dit?", test));
    }

	private IEnumerator CountingDown(float waitTime)
    {
        while (seconds > 0)
        {
            seconds--;

            yield return new WaitForSeconds(waitTime);
        }

    }

    private IEnumerator CountingDown2(float waitTime, int test1, string hello, Testing method)
    {
        while (seconds > 0)
        {
            seconds--;
            Debug.Log("This working? float: " + waitTime + ", int: " + test1 + ", string: " + hello);
            yield return new WaitForSeconds(waitTime);
        }
        method();
    }

    private void log()
    {
        Debug.Log("Wow it actually worked");
    }*/
}
