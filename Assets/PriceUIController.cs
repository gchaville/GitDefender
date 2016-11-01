using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PriceUIController : MonoBehaviour {

    public GameObject icon;
    Text price;
	// Use this for initialization
	void Start () {
        price = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        price.text = icon.GetComponent<UIModuleController>().nbrRessources.ToString();
	}
}
