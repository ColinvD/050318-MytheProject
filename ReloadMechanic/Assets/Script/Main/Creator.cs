using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour
{

    /// <summary> This script is meant for overall function calling. </summary> ///

    [Header("Game objects(s)")]
    public GameObject theProjectile;

	void Start()
    {
	}
	
	void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            InstantiateProjectile();
        }
    }

    public void InstantiateProjectile()
    {
        Instantiate(theProjectile);
    }

}
