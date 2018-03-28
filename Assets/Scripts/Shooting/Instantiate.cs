using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{

    [SerializeField]
    private GameObject[] projectiles;

    private GameObject theCurrentProjectile;

    public bool projectileIsDown = false;

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
