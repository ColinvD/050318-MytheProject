using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor : MonoBehaviour
{

    public Rigidbody2D theRigidbody2DAnchor;

	void Start ()
    {
        theRigidbody2DAnchor = GetComponent<Rigidbody2D>();
	}
	
}
