using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public GameObject up;
    public GameObject down;
    public GameObject left;
    public GameObject right;
    public GameObject player;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(player.transform.position.x, left.transform.position.x, right.transform.position.x), Mathf.Clamp(player.transform.position.y, down.transform.position.y, up.transform.position.y), 0);
    }
}
