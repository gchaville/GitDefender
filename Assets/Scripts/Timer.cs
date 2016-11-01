using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    private Text timer;
    private float startTime;
	private int minutes;
	private int seconds;

	// Use this for initialization
	void Start () {

        startTime = Time.time;
		timer = this.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {

        float t = Time.time - startTime;
        minutes = ((int)t / 60);
		seconds = ((int)t % 60);
	
		if (minutes > 0)
			timer.text = seconds <= 9 ? "time " + minutes + ":0" + seconds : "time " + minutes + ":" + seconds;
		else
			timer.text = seconds <= 9 ? "time 0" + seconds : "time " + seconds;

	}
}
