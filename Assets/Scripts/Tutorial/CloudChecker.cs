using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudChecker : MonoBehaviour {

    [SerializeField]
    private List<CloudStruct> cloudTutorial;
    [SerializeField]
    private TutorialChanger changer;

    //void Start()
    //{
    //    HasSeen("hello");
    //}

    public void HasSeen(string cloudType)
    {
        //bool hasSeen = false;
        for (int i = 0; i < cloudTutorial.Count; i++)
        {
            if (cloudTutorial[i].type == cloudType /*&& cloudTutorial[i].seen == false*/)
            {
                cloudTutorial.Remove(cloudTutorial[i]);
                changer.SetTutorialMessage(cloudType);
                //hasSeen = true;
                break;
            }
        }
        //return hasSeen;
    }
}

[Serializable]
public struct CloudStruct
{
    public string type;
    //public bool seen;
    public CloudStruct(string t, bool s)
    {
        type = t;
        //seen = s;
    }
}