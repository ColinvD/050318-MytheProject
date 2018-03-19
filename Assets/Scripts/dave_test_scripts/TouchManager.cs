using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    
    /*[SerializeField]
    private GameObject particle;*/

    public Vector2 newPosition;

    [SerializeField]
    private float dragSpeed = 0.5f;

    void Start ()
    {
        
	}

	
	void Update ()
    {

        /*(if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            newPosition = Input.GetTouch(0).position;
        }*/

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

            transform.Translate(-touchDeltaPosition.x * dragSpeed, -touchDeltaPosition.y * dragSpeed, 0);
        }

    }

}
