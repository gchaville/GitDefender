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
        float move = Input.GetAxisRaw("Horizontal");
        if (move != 0)
        {
            anim.SetBool("isMoving", true);
            if (move < 0)
            {
                this.transform.localScale = new Vector2(-0.4f, this.transform.localScale.y);
            }
            else
            {
                this.transform.localScale = new Vector2(0.4f, this.transform.localScale.y);
            }
        }
        else
        {
            anim.SetBool("isMoving", false);
        }

        rBody.velocity = new Vector2(move * m_speed, rBody.velocity.y);

        if(grounded)
        {
            anim.SetBool("isFalling", false);

            if (Input.GetButtonDown("Jump"))
            {
                if(CanJumpDown == false)
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
      
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (GameManager.instance.IndexItem == 2)
                GameManager.instance.IndexItem = 0;
            else
                GameManager.instance.IndexItem++;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (moduleSpawn != null && moduleSpawn.GetComponent<SpawnModuleController>().Busy == false)
            {
                myModule = Instantiate(listModule[GameManager.instance.IndexItem], moduleSpawn.transform.position, Quaternion.identity) as GameObject;
                myModule.GetComponent<ModuleController>().mySpawnModule = moduleSpawn;
                moduleSpawn.GetComponent<SpawnModuleController>().Busy = true;
            }
        }

        if (rBody.velocity.y < 0)
        {
            anim.SetBool("isFalling", true);
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

    IEnumerator Wait()
    {
        waitForEnemy = false;
        yield return new WaitForSeconds(0.1f);
        waitForEnemy = true;
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
<<<<<<< HEAD
            if(waitForEnemy)
            {
               	anim.SetTrigger("isJumping");
                source.volume = 0.2f;
                source.PlayOneShot(jumpSound, 1);
                rBody.velocity = new Vector2(rBody.velocity.x, 8);
                other.GetComponent<Enemy>().launchDeath();
				GameManager.instance.getCamera ().setShake (0.2f);
                StartCoroutine(Wait());
            }
=======
            Physics2D.IgnoreCollision(lastPlatform, GetComponent<BoxCollider2D>(), false);
            Physics2D.IgnoreCollision(lastPlatform, GetComponent<Collider2D>(), false);

            Physics2D.IgnoreCollision(lastPlatform, groundCheck.GetComponent<BoxCollider2D>(), false);
            Physics2D.IgnoreCollision(lastPlatform, groundCheck.GetComponent<Collider2D>(), false);

            lastPlatform = null;
            lastPlatformName = null;
>>>>>>> 04b16029f1be8f35423ce193eb6a4e6f2cd43dcb
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
