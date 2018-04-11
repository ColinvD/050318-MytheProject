using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreenVisable : MonoBehaviour {

    [SerializeField]
    private GameObject pauseScreen;

	public void Show()
    {
        pauseScreen.SetActive(!pauseScreen.active);
    }
}
