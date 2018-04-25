using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActivator : MonoBehaviour {

    [SerializeField] private GameObject go;

	public void Show()
    {
        go.SetActive(!go.active);
    }
}
