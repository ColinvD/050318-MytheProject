using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload : MonoBehaviour
{
    [SerializeField]
    private GameObject[] projectiles;
    [SerializeField]
    private GameObject[] viewSlotOne;
    [SerializeField]
    private GameObject[] viewSlotTwo;
    [SerializeField]
    private GameObject[] viewSlotThree;

    private GameObject theCurrentProjectile;

    /*public GameObject theCurrentViewSlot;*/

    private GameObject FirstSlot;

    private GameObject SecondSlot;
    private GameObject ThirdSlot;

    public bool projectileIsDown = false;

    private int index;

    void Start()
    {
        StartProjectile();
        StartingFill();
        GetNewFillSlot();
        /*ReloadWithPreview();*/
    }

    void Update()
    {
    }

    public void StartProjectile()
    {
        index = Random.Range(0, projectiles.Length);
        theCurrentProjectile = projectiles[index];
		//Debug.Log(projectiles[index]);
        Instantiate(theCurrentProjectile);

        /*Debug.Log(theCurrentProjectile.name);*/

        projectileIsDown = false;
    }

    public void StartingFill()
    {
        index = Random.Range(0, viewSlotTwo.Length);
        SecondSlot = viewSlotTwo[index];
        Instantiate(SecondSlot);

        index = Random.Range(0, viewSlotOne.Length);
        FirstSlot = viewSlotOne[index];
        Instantiate(FirstSlot);
    }

    public void PushSlotOne()
    {
        //FirstSlot = viewSlotOne[index];

        if (FirstSlot.name == "Projectile view slot one (1)")
        {
            Instantiate(projectiles[0]);
        }

        if (FirstSlot.name == "Projectile view slot one (2)")
        {
            Instantiate(projectiles[1]);
        }

        if (FirstSlot.name == "Projectile view slot one (3)")
        {
            Instantiate(projectiles[2]);
        }

        if (FirstSlot.name == "Projectile view slot one (4)")
        {
            Instantiate(projectiles[3]);
        }
    }

    public void PushSlotTwo()
    {
        //SecondSlot = viewSlotTwo[index];

        if (SecondSlot.name == "Projectile view slot two (1)")
        {
            FirstSlot = viewSlotOne[0];
            Instantiate(FirstSlot);
        }

        if (SecondSlot.name == "Projectile view slot two (2)")
        {
            FirstSlot = viewSlotOne[1];
            Instantiate(FirstSlot);
        }

        if (SecondSlot.name == "Projectile view slot two (3)")
        {
            FirstSlot = viewSlotOne[2];
            Instantiate(FirstSlot);
        }

        if (SecondSlot.name == "Projectile view slot two (4)")
        {
            FirstSlot = viewSlotOne[3];
            Instantiate(FirstSlot);
        }
    }

    public void PushSlotThree()
    {
        //ThirdSlot = viewSlotThree[index];

        if (ThirdSlot.name == "Projectile view slot three (1)")
        {
            SecondSlot = viewSlotTwo[0];
            Instantiate(SecondSlot);
        }

        if (ThirdSlot.name == "Projectile view slot three (2)")
        {
            SecondSlot = viewSlotTwo[1];
            Instantiate(SecondSlot);
        }

        if (ThirdSlot.name == "Projectile view slot three (3)")
        {
            SecondSlot = viewSlotTwo[2];
            Instantiate(SecondSlot);
        }

        if (ThirdSlot.name == "Projectile view slot three (4)")
        {
            SecondSlot = viewSlotTwo[3];
            Instantiate(SecondSlot);
        }
    }

    public void GetNewFillSlot()
    {
        index = Random.Range(0, viewSlotThree.Length);
        ThirdSlot = viewSlotThree[index];
        Instantiate(ThirdSlot);
        /*Debug.Log(theCurrentViewSlot.name);*/
    }


    public void ReloadProcess()
    {
        PushSlotOne();
        PushSlotTwo();
        PushSlotThree();
        GetNewFillSlot();
    }

    //Make gameobject of the initialized Array object, so you can delete it after.
    //To delete it must be a object or atleast reference it.

}
