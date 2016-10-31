using UnityEngine;
using System.Collections;

public class GlitchEffect : MonoBehaviour {

	public GameObject glitchObject;

	public void launchGlitch(){
		int nbGlitch = (int)Random.Range (20f, 50f);
		for (int i = 0; i < nbGlitch; i++) {
			GameObject toInstantiate = Instantiate (glitchObject, this.transform.position, Quaternion.identity) as GameObject;
			toInstantiate.GetComponent<SpriteRenderer> ().color = new Color(Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f));
			toInstantiate.transform.position = new Vector3 (Random.Range (-9f, 9f), Random.Range (-5f, 5f), 0f);
			toInstantiate.transform.localScale = new Vector3 (Random.Range (0f, 2f), Random.Range (0f, 2f), 0f);
			Destroy(toInstantiate, Random.Range(0.1f, 0.5f));
		}
	}

	public void launchGlitchGameOver(){
		int nbGlitch = (int)Random.Range (20f, 50f);
		for (int i = 0; i < nbGlitch; i++) {
			GameObject toInstantiate = Instantiate (glitchObject, this.transform.position, Quaternion.identity) as GameObject;
			toInstantiate.GetComponent<SpriteRenderer> ().color = new Color(Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f));
			toInstantiate.transform.position = new Vector3 (Random.Range (-9f, 9f), Random.Range (-5f, 5f), 0f);
			toInstantiate.transform.localScale = new Vector3 (Random.Range (0f, 2f), Random.Range (0f, 2f), 0f);
			Destroy(toInstantiate, Random.Range(5f, 10f));
		}
	}
}
