using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialChanger : MonoBehaviour {

    [SerializeField]
    private List<GameObject> tutorialPrefabs;
    [SerializeField]
    private GameObject canvas;
    private FollowTutorial followTutorial;

    void Start()
    {
        followTutorial = FindObjectOfType<FollowTutorial>();
    }

    public void SetTutorialMessage(string type)
    {
        if (followTutorial.GetDoTutorial())
        {
            switch (type)
            {
                case "hello":
                    Instantiate(tutorialPrefabs[0], canvas.transform);
                    break;
                case "hi":
                    Instantiate(tutorialPrefabs[1], canvas.transform);
                    break;
            }
            FindObjectOfType<StopTime>().ChangeTime(0);
        }
    }

}
