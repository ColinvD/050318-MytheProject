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

    public void NextOne()
    {
        nextTutorial.SetActive(true);
        Destroy(gameObject);
    }
}
