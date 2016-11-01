using UnityEngine;
using System.Collections;

public class SerieBitController : MonoBehaviour {

    public int power;
    int randomScale;

    // Use this for initialization
    void Start () {
        power = Random.Range(5, 11);
        StartCoroutine(Wait());
        randomScale = Random.Range(1, 4);
        transform.localScale = new Vector3(randomScale, randomScale, randomScale);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * Time.deltaTime * power);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }
}
