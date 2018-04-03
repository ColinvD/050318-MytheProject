using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChecking : MonoBehaviour
{

    /// <summary> This script is meant for checking color. </summary> ///

    [Header("String(s)")]
    public string ballColor;

    [Header("Component(s)")]
    private SpriteRenderer theSpriteRenderer;

    void Start ()
    {
        theSpriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	void Update ()
    {
	}

    public void CheckColor()
    {
        if(theSpriteRenderer.sprite.name == "blauw")
        {
            ballColor = "blauw";
        }

        if (theSpriteRenderer.sprite.name == "geel")
        {
            ballColor = "geel";
        }

        if (theSpriteRenderer.sprite.name == "rood")
        {
            ballColor = "rood";
        }

        if (theSpriteRenderer.sprite.name == "roze")
        {
            ballColor = "roze";
        }

        Debug.Log(ballColor);
    }

}
