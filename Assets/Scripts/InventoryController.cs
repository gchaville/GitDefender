using UnityEngine;
using System.Collections;

public class InventoryController : MonoBehaviour {

    public GameObject[] moduleIcons;
    public GameObject arrow;

    public int indexInventory = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if(indexInventory != GameManager.instance.IndexItem)
        {
            indexInventory = GameManager.instance.IndexItem;

            arrow.transform.position = new Vector3(moduleIcons[indexInventory].transform.position.x + 2.5f, arrow.transform.position.y, arrow.transform.position.z);
        }
	}
}
