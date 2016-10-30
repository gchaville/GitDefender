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
                anim.SetTrigger("isJumping");
                source.volume = 0.2f;
                source.PlayOneShot(jumpSound, 1);
                rBody.velocity = new Vector2(rBody.velocity.x, j_force);

                grounded = false;
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "ground")
        {
            grounded = true;
        }
        else if(other.gameObject.tag == "Ennemy")
        {
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
        }
    }

    IEnumerator Wait()
    {
        waitForEnemy = false;
        yield return new WaitForSeconds(0.1f);
        waitForEnemy = true;
    }
}
