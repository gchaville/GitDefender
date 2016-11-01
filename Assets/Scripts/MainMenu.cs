using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

	public string levelname;

	public GameObject tutoPanel;
	public GameObject mainPanel;

	public Button[] mainButton;
	private int cptMainMenu = 0;

	private bool isTuto = false;

	void Awake(){
		tutoPanel.SetActive (false);
		mainButton [cptMainMenu].Select ();	 
	}

	void Update () {
		if (!isTuto) {
			if (Input.GetKeyDown (KeyCode.Z)) {
				cptMainMenu--;
				if (cptMainMenu < 0)
					cptMainMenu = 2;
				mainButton [cptMainMenu].Select ();	 
			} else if (Input.GetKeyDown (KeyCode.S)) {
				cptMainMenu++;
				if (cptMainMenu > 2)
					cptMainMenu = 0 ;
				mainButton [cptMainMenu].Select ();
			}
			if (Input.GetKeyDown (KeyCode.Space)) {
				switch (cptMainMenu) {
				case 0:
					StartGame ();
					break;
				case 1:
					if (!isTuto) {
						mainPanel.SetActive (false);
						tutoPanel.SetActive (true);
						isTuto = true;
					}
					break;
				case 2:
					QuitGame ();
					break;
				}
			}
		} else {
			if ((Input.GetKeyDown (KeyCode.Space))||(Input.GetKeyDown (KeyCode.Escape))) {
				mainPanel.SetActive (true);
				tutoPanel.SetActive (false);
				isTuto = false;
			}
		}
	}

	public void StartGame() 
	{
		SceneManager.LoadScene("BigSceneHugo");

	}

	public void QuitGame() 
	{
		Application.Quit();
	}
}
