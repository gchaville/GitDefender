using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float m_speed;
    public float j_force;
    public AudioClip jumpSound;

    public GameObject[] listModule;

    private Rigidbody2D rBody;
    private AudioSource source;

    private Animator anim;
    private GameObject moduleSpawn = null;

    private GameObject myModule;
    private bool waitForEnemy = true;

    public bool grounded = false;

    public Collider2D lastPlatform;
    public string lastPlatformName;

    public bool CanJumpDown;
    public GameObject groundCheck;

    private bool Stun = false;
    private bool Invisible = false;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(!Stun)
        {
            float move = Input.GetAxisRaw("Horizontal");
            if (move != 0)
            {
                anim.SetBool("isMoving", true);
                if (move < 0)
                {
                    this.transform.localScale = new Vector2(-0.4f, this.transform.localScale.y);//*********************************************
                }
                else
                {
                    this.transform.localScale = new Vector2(0.4f, this.transform.localScale.y);//***********************************************
                }
            }
            else
            {
                anim.SetBool("isMoving", false);
            }

            rBody.velocity = new Vector2(move * m_speed, rBody.velocity.y);

            if (grounded)
            {
                anim.SetBool("isFalling", false);

                if (Input.GetButtonDown("Jump"))
                {
                    if (CanJumpDown == false)
                    {
                        anim.SetTrigger("isJumping");
                        source.volume = 0.2f;
                        source.PlayOneShot(jumpSound, 1);
                        rBody.velocity = new Vector2(rBody.velocity.x, j_force);

                        grounded = false;
                    }
                    else
                    {

                        downJump(groundCheck.GetComponent<GroundCheckController>().platformDownJump);
                    }
                }
            }

            if (Input.GetButtonDown("UIRight"))
            {
                if (GameManager.instance.IndexItem == 2)
                    GameManager.instance.IndexItem = 0;
                else
                    GameManager.instance.IndexItem++;
            }

            if (Input.GetButtonDown("UILeft"))
            {
                if (GameManager.instance.IndexItem == 0)
                    GameManager.instance.IndexItem = 2;
                else
                    GameManager.instance.IndexItem--;
            }

            if (Input.GetButtonDown("Fire1"))
            {
                if (moduleSpawn != null && moduleSpawn.GetComponent<SpawnModuleController>().Busy == false && GameManager.instance.Ressource >= listModule[GameManager.instance.IndexItem].GetComponent<ModuleController>().Ressource)
                {
                    myModule = Instantiate(listModule[GameManager.instance.IndexItem], moduleSpawn.transform.position, Quaternion.identity) as GameObject;
                    myModule.GetComponent<ModuleController>().mySpawnModule = moduleSpawn;
                    moduleSpawn.GetComponent<SpawnModuleController>().Busy = true;

                    GameManager.instance.Ressource -= listModule[GameManager.instance.IndexItem].GetComponent<ModuleController>().Ressource;
                }
            }

            if (rBody.velocity.y < 0)
            {
                anim.SetBool("isFalling", true);
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "ModuleSpawn")
        {
            moduleSpawn = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "ModuleSpawn")
        {
            moduleSpawn = null;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ennemy" && Invisible == false)
        {
            Invisible = true;
            gameObject.layer = 10;
            groundCheck.layer = 10;

            rBody.velocity = Vector3.zero;

            /*if (coll.gameObject.transform.position.x > transform.position.x)
            {
                rBody.AddForce(Vector2.left * 100);
            }
            else
            {
                rBody.AddForce(Vector2.right * 100);
            }*/

            StartCoroutine(StunPlayer());
            StartCoroutine(Flasher());
        }
    }

    IEnumerator Wait()
    {
        waitForEnemy = false;
        yield return new WaitForSeconds(0.1f);
        waitForEnemy = true;
    }

    IEnumerator StunPlayer()
    {
        Stun = true;
        yield return new WaitForSeconds(1f);
        Stun = false;

        groundCheck.layer = 9;
    }

    IEnumerator Flasher()
    {
        for (int i = 0; i < 10; i++)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(.1f);
            GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(.1f);
        }

        Invisible = false;
        gameObject.layer = 9;

    }

    public void downJump(Collider2D other)
    {
        grounded = false;

        anim.SetTrigger("isJumping");
        source.volume = 0.2f;
        source.PlayOneShot(jumpSound, 1);
        rBody.velocity = new Vector2(rBody.velocity.x, 4);

        

        lastPlatformName = other.transform.name;
        lastPlatform = other.transform.GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(lastPlatform, GetComponent<BoxCollider2D>());
        Physics2D.IgnoreCollision(lastPlatform, GetComponent<Collider2D>());
    }

	public void landDownJump(Collider2D other)
	{
		grounded = true;
		CanJumpDown = false;

		if (other.transform.name != lastPlatformName)
		{
			Physics2D.IgnoreCollision(lastPlatform, GetComponent<BoxCollider2D>(), false);
			Physics2D.IgnoreCollision(lastPlatform, GetComponent<Collider2D>(), false);

			Physics2D.IgnoreCollision(lastPlatform, groundCheck.GetComponent<BoxCollider2D>(), false);
			Physics2D.IgnoreCollision(lastPlatform, groundCheck.GetComponent<Collider2D>(), false);

			lastPlatform = null;
			lastPlatformName = null;
		}
	}

    public void jumpOnEnnemy(Collider2D other)
    {
        if (waitForEnemy)
        {
            source.volume = 0.2f;
            source.PlayOneShot(jumpSound, 1);
            rBody.velocity = new Vector2(rBody.velocity.x, 8);
            other.GetComponent<Enemy>().launchDeath();
            GameManager.instance.getCamera().setShake(0.2f);
            StartCoroutine(Wait());
        }
    }
}
