using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float m_speed = 1f;
    public float j_force = 1f;
    public AudioClip jumpSound;
    public GameObject[] listModule;

    private Rigidbody2D rBody;
    private AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    
    // Use this for initialization
    void Start() { 
        rBody = GetComponent<Rigidbody2D>();
    }

    // Déclaration de la variable de vitesse
    


    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");

        rBody.velocity = new Vector2(move * m_speed, rBody.velocity.y);

        if (rBody.velocity.y == 0)
        {
            //holding jump button//
            if (Input.GetButtonDown("Jump"))
            {
                source.PlayOneShot(jumpSound, 1);
                rBody.AddForce(new Vector2(0, j_force));
            }
            else if (Input.GetKeyDown(KeyCode.Z))
            {
                if (GameManager.instance.IndexItem == 2)
                {
                    GameManager.instance.IndexItem = 0;
                }
                else
                {
                    GameManager.instance.IndexItem++;
                }
            }
            else if (Input.GetKeyDown(KeyCode.X))
            {
                source.PlayOneShot(jumpSound, 1);
                Instantiate(listModule[GameManager.instance.IndexItem], transform.position, Quaternion.identity);
            }
        }
    }
}
