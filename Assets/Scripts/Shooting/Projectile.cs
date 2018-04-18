using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float releaseTime = .05f;
    [SerializeField]
    private float maximumRatio = 1.5f;

    private Rigidbody2D theRigidbody2DProjectile;
    private SpriteRenderer theSpriteRenderer;
    private SpringJoint2D theSpringJoint2D;

    private bool isPressed = false;
    private bool isRendering;

    public Anchor theAnchorScript;
    /*public Touch theTouchScript;*/
    public Instantiate theInstantiateScript;
    public Reload theReloadScript;

    private Vector2 mousePosition;

    void Start()
    {
        theRigidbody2DProjectile = GetComponent<Rigidbody2D>();
        theSpringJoint2D = GetComponent<SpringJoint2D>();
        theSpriteRenderer = GetComponent<SpriteRenderer>();
		
		theReloadScript = FindObjectOfType<Reload>();

        theSpringJoint2D.frequency = 5f;
	}
	
	void Update()
    {
        if (isPressed)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Vector3.Distance(mousePosition, theAnchorScript.theRigidbody2DAnchor.position) > maximumRatio)
            {
                theRigidbody2DProjectile.position = theAnchorScript.theRigidbody2DAnchor.position + (mousePosition - theAnchorScript.theRigidbody2DAnchor.position).normalized * maximumRatio;
            }
            else
            {
                theRigidbody2DProjectile.position = mousePosition;
            }
        }

        CheckForOffScreen();
	}

    void OnMouseDown()
    {
        isPressed = true;
        /*Debug.Log("Mouse click down");*/
        theRigidbody2DProjectile.isKinematic = true;
    }

    void OnMouseUp()
    {
        isPressed = false;
        /*Debug.Log("Mouse click up");*/
        theRigidbody2DProjectile.isKinematic = false;

        StartCoroutine(ReleaseTheProjectile());
    }

    public void OnDeath()
    {
        /*Debug.Log("Death");*/

        this.gameObject.SetActive(false);

        /*theInstantiateScript.GetNewProjectile();*/
        theReloadScript.ReloadProcess();

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

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Cloud"))
        {
            OnDeath();
        }
    }

}
