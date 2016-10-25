using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UiModulesController : MonoBehaviour {

    public Sprite[] ListSprite;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(GameManager.instance.IndexItem == 0)
        {
            GetComponent<Image>().sprite = ListSprite[0];
        }
        else if (GameManager.instance.IndexItem == 1)
        {
            GetComponent<Image>().sprite = ListSprite[1];
        }
        else if (GameManager.instance.IndexItem == 2)
        {
            GetComponent<Image>().sprite = ListSprite[2];
        }
	}
}
