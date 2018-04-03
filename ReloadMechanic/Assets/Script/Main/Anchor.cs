using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor : MonoBehaviour
{

    /// <summary> This script is meant for everything regarding the anchor. </summary> ///
    
    [Header("Component(s)")]
    public Rigidbody2D theRigidbody2DAnchor;

	void Start ()
    {
        theRigidbody2DAnchor = GetComponent<Rigidbody2D>();
	}
	
}
