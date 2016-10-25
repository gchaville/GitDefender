using UnityEngine;
using System.Collections;

public class Youssef_Script : MonoBehaviour {

    private bool onGround;
    private float jumpPresure;
    private float minJump;
    private float maxJumpPresure;
   private Rigidbody rBody;

	// Use this for initialization
	void Start () {

        onGround = true;
        jumpPresure = 0f;
        minJump = 1f;
        maxJumpPresure = 4f;
       rBody = GetComponent<Rigidbody>();
	
	}

    // Déclaration de la variable de vitesse
    public float m_speed = 0.1f;


    // Update is called once per frame
    void Update () {
        if(onGround)
        {
            //holding jump button//
            if(Input.GetButton("Jump"))
            {
                if(jumpPresure < maxJumpPresure)
                {
                    jumpPresure += Time.deltaTime * 4f;
                }
                else
                {
                    jumpPresure = maxJumpPresure;
                }
                print(jumpPresure);
            }
            //not holding jump button//
            else
            {
                //jump//
                if(jumpPresure > 0f)
                {
                    jumpPresure = jumpPresure + minJump;
                    rBody.velocity = new Vector3(jumpPresure / 4f, jumpPresure, 1f);
                    jumpPresure = 0f;
                    onGround = false;
                }

            }
        }

        // Création d'un nouveau vecteur de déplacement
        Vector3 move = new Vector3();

        // Récupération des touches haut et bas
        if (Input.GetKey(KeyCode.UpArrow))
            move.z += m_speed;
        if (Input.GetKey(KeyCode.DownArrow))
            move.z -= m_speed;

        // Récupération des touches gauche et droite
        if (Input.GetKey(KeyCode.LeftArrow))
            move.x -= m_speed;
        if (Input.GetKey(KeyCode.RightArrow))
            move.x += m_speed;

        // On applique le mouvement à l'objet
        transform.position += move;

    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("ground"))
        {
            onGround = true;
        }
    }

   
}
