using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{

    public TouchManager touchManagerScript;

    private Vector2 theParticlePosition;

    private float movementSpeed = 4;
    private float moving;

	void Start ()
    {
        transform.position = theParticlePosition;
	}
	
	void Update ()
    {
        Debug.Log(theParticlePosition);
        ChangeToNewPosition();
        /*transform.Translate(-theParticlePosition.x * movementSpeed, -theParticlePosition.y * movementSpeed, 0);*/
    }

    public void ChangeToNewPosition()
    {
        theParticlePosition = touchManagerScript.newPosition;
        moving = movementSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, theParticlePosition, moving);
    }
}
