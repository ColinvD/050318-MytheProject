using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetFollowTutorial : MonoBehaviour {

    [SerializeField]
    private Toggle toggle;
    private FollowTutorial tutorial;

	// Use this for initialization
	void Start () {
        tutorial = FindObjectOfType<FollowTutorial>();
        toggle.isOn = tutorial.GetDoTutorial();
	}

    public void ChangeIt()
    {
        tutorial.SetDoTutorial(toggle.isOn);
    }
}
