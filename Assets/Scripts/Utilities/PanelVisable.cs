using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelVisable : MonoBehaviour {

    [SerializeField]
    private GameObject screen;

	public void Show()
    {
        screen.SetActive(!screen.active);
    }
}
