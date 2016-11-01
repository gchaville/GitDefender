using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Pause : MonoBehaviour {

    public bool paused;
	public PlayerController controller;
	public Canvas pauseCanvas;

	// Use this for initialization
	void Start () {

        paused = false;
		controller = controller.GetComponent<PlayerController> ();
		pauseCanvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown("Pause"))
			PauseGame ();
	}

	public void PauseGame() 
	{
		paused = !paused;
		controller.enabled = !paused;
		pauseCanvas.enabled = paused;

		if (paused)
			Time.timeScale = 0;
		else
			Time.timeScale = 1;

	}

	public void Quit() {
		SceneManager.LoadScene ("MainMenu");
	}

	public void Restart() {
		PauseGame ();
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}
}
