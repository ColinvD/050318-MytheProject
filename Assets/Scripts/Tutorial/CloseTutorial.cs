using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseTutorial : MonoBehaviour {

    private void OnMouseDown()
    {
        FindObjectOfType<StopTime>().ChangeTime(1);
        Destroy(gameObject);
    }
}
