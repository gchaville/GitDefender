using UnityEngine;
using System.Collections;

public class HealthBarController : MonoBehaviour {

    public GameObject Module;
    public Sprite PeuDeVie;
    public float MaxLife;

	// Use this for initialization
	void Awake () {
        MaxLife = Module.GetComponent<ModuleController>().life;
	}
	
	// Update is called once per frame
	void Update () {

        transform.localScale = new Vector3((Module.GetComponent<ModuleController>().life * 2) / MaxLife, 0.5f, 1);

        if(transform.localScale.x < 0.8)
        {
            GetComponent<SpriteRenderer>().sprite = PeuDeVie;
        }


	}
}
