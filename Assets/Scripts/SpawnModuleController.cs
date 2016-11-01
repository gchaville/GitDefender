using UnityEngine;
using System.Collections;

public class SpawnModuleController : MonoBehaviour {

    public bool Busy = false;
    public GameObject aura;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && Busy == false)
        {
            aura.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            aura.SetActive(false);
        }
    }
}
