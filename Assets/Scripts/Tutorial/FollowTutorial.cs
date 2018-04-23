using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTutorial : MonoBehaviour {

    [SerializeField]
    private bool doTutorial = true;

	// Use this for initialization
	void Start () {
        if (FindObjectsOfType<FollowTutorial>().Length < 2)
        {
            Debug.Log(FindObjectsOfType<FollowTutorial>().Length);
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
	}

    public void SetDoTutorial(bool setTo)
    {
        doTutorial = setTo;
    }

    public bool GetDoTutorial()
    {
        return doTutorial;
    }
}
