using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDestroy : MonoBehaviour {
    [SerializeField]
    private GameObject nextTutorial;
    private StopTime timeManager;

    void Start()
    {
        timeManager = FindObjectOfType<StopTime>();
        timeManager.ChangeTime(0);
    }
    void Update()
    {
        if (Time.timeScale == 1)
        {
            timeManager.ChangeTime(0);
        }
    }
    private void OnMouseDown()
    {
        NextOne();
    }
    public void NextOne()
    {
        nextTutorial.SetActive(true);
        Destroy(gameObject);
    }
}
