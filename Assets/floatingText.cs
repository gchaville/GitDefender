using UnityEngine;
using System.Collections;

public class floatingText : MonoBehaviour {

	private Transform thisTransform;
	private RectTransform rectTransform;


	// Use this for initialization
	void Start () {
		thisTransform = transform;
		rectTransform = this.GetComponent<RectTransform> ();
		rectTransform.SetSiblingIndex (-1);


	}
	
	// Update is called once per frame
	void Update () {
		thisTransform.LookAt(thisTransform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
	}
}
