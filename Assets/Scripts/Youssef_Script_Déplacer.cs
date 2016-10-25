using UnityEngine;
using System.Collections;

public class Youssef_Script_Déplacer : MonoBehaviour {

	// Use this for initialization
	void Start () {

 
}
    // Déclaration de la variable de vitesse
    public float m_speed = 0.1f;

    // Update is called once per frame
    void Update () {
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
}
