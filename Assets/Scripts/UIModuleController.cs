using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIModuleController : MonoBehaviour {

    public int nbrRessources;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if(GameManager.instance.Ressource < nbrRessources)
        {
            GetComponent<Image>().color = new Color32(128, 128, 128, 255);
        }
        else
        {
            GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
	}
}
