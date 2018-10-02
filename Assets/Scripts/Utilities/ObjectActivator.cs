using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActivator : MonoBehaviour {

    [SerializeField] private GameObject panel;

	public void Show()
    {
		panel.SetActive(!panel.active);
    }
}
