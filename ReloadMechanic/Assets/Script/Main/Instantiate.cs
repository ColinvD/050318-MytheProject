using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{

    /// <summary> This script is meant for testing the instantiation of a random single ball. </summary> ///

    [Header("Game object(s)")]
    [SerializeField]
    private GameObject[] projectiles;
    private GameObject theCurrentProjectile;

    [Header("Boolean(s)")]
    public bool projectileIsDown = false;

    [Header("Int(s)")]
    private int index;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GetNewProjectile();
        }
    }

    public void GetNewProjectile()
    {
        index = Random.Range(0, projectiles.Length);
        theCurrentProjectile = projectiles[index];
        Instantiate(theCurrentProjectile);

        /*Debug.Log(theCurrentProjectile.name);*/

        projectileIsDown = false;
    }
}
