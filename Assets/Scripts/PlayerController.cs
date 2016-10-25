using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float m_speed = 1f;
    public float j_force = 1f;

    private Rigidbody2D rBody;

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
                rBody.AddForce(new Vector2(0, j_force));
            }
        }
    }
}
