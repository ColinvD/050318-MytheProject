using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float releaseTime = .05f;
    [SerializeField]
    private float maximumRatio = 1.5f;

    private Rigidbody2D theRigidbody2DParticle;
    private SpringJoint2D theSpringJoint2D;
    private SpriteRenderer theSpriteRenderer;

    private bool isPressed = false;
    private bool isRendering;

    public Anchor theAnchorScript;
    private Touch theTouchScript;

    private Vector2 mousePosition;

    void Start ()
    {
        theRigidbody2DParticle = GetComponent<Rigidbody2D>();
        theSpringJoint2D = GetComponent<SpringJoint2D>();
        theSpriteRenderer = GetComponent<SpriteRenderer>();

        theSpringJoint2D.frequency = 5f;
        theSpringJoint2D.enableCollision = false;
	}
	
	void Update ()
    {
        if (isPressed)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Vector3.Distance(mousePosition, theAnchorScript.theRigidbody2DAnchor.position) > maximumRatio)
            {
                theRigidbody2DParticle.position = theAnchorScript.theRigidbody2DAnchor.position + (mousePosition - theAnchorScript.theRigidbody2DAnchor.position).normalized * maximumRatio;
            }
            else
            {
                theRigidbody2DParticle.position = mousePosition;
            }
        }

        CheckForOffScreen();
	}

    void OnMouseDown()
    {
        isPressed = true;
        /*Debug.Log("Mouse click down");*/
        theRigidbody2DParticle.isKinematic = true;
    }

    void OnMouseUp()
    {
        isPressed = false;
        /*Debug.Log("Mouse click up");*/
        theRigidbody2DParticle.isKinematic = false;

        StartCoroutine(ReleaseTheProjectile());
    }

    void OnDeath()
    {
        Debug.Log("Death");
        Destroy(this.gameObject);
    }

    void CheckForOffScreen()
    {
        if (theSpriteRenderer.isVisible)
        {
            isRendering = true;
        }
        else if (isRendering && !theSpriteRenderer.isVisible)
        {
            OnDeath();
        }
    }

    IEnumerator ReleaseTheProjectile()
    {
        yield return new WaitForSeconds(releaseTime);

        theSpringJoint2D.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Cloud"))
        {
            OnDeath();
        }
    }



}
