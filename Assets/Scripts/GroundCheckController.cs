using UnityEngine;
using System.Collections;

public class GroundCheckController : MonoBehaviour {

    PlayerController parent;
    public Collider2D platformDownJump;
	// Use this for initialization
	void Start () {
        parent = transform.parent.gameObject.GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {

    }
    
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            if (Input.GetAxisRaw("Vertical") < -0.5f)
            {
                parent.CanJumpDown = true;
                platformDownJump = other;
            }
            else
            {
                parent.CanJumpDown = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Ennemy")
        {
            parent.jumpOnEnnemy(other);
        }
        else if ((other.gameObject.tag == "ground" || other.gameObject.tag == "bigGround") && other.transform.name != parent.lastPlatformName)
        {
            parent.landDownJump(other);

            //Physics2D.IgnoreCollision(parent.lastPlatform, GetComponent<BoxCollider2D>(), false);
            //Physics2D.IgnoreCollision(parent.lastPlatform, GetComponent<Collider2D>(), false);
        }
    }
}
