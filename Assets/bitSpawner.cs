using UnityEngine;
using System.Collections;

public class bitSpawner : MonoBehaviour {

    public GameObject up;
    public GameObject down;
    public GameObject[] seriesDeBits;

	// Use this for initialization
	void Start () {
        Invoke("LaunchProjectile", 1);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    
    void LaunchProjectile()
    {
        Instantiate(seriesDeBits[Random.Range(0, seriesDeBits.Length)], new Vector3(transform.position.x, Random.Range(down.transform.position.y, up.transform.position.y), transform.position.z), Quaternion.identity);
        Invoke("LaunchProjectile", Random.Range(0.5f, 2f));
    }
}
