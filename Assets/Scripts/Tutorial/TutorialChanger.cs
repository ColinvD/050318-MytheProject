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
        if (followTutorial == null)
        {
            followTutorial = gameObject.AddComponent<FollowTutorial>();
        }
    }

    public void SetTutorialMessage(string type)
    {
        if (followTutorial.GetDoTutorial())
        {
            switch (type)
            {
                case "gewoon":
                    Instantiate(tutorialPrefabs[0], canvas.transform);
                    break;
                case "regen":
                    Instantiate(tutorialPrefabs[1], canvas.transform);
                    break;
                case "donder":
                    Instantiate(tutorialPrefabs[2], canvas.transform);
                    break;
            }
            FindObjectOfType<StopTime>().ChangeTime(0);
        }
    }

}
