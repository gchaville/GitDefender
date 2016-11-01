using UnityEngine;
using System.Collections;

public class SerieBitController : MonoBehaviour {

    public int power;
	// Use this for initialization
	void Start () {
        power = 10;
        StartCoroutine(Wait());
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * Time.deltaTime * power);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
