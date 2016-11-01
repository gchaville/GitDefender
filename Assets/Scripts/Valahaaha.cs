using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Valahaaha : MonoBehaviour
{

	public GameObject bash;
	public GameObject[] buttons;

	public string levelname;

	void Start()
	{
		bash.SetActive(false);
	}

	public void StartGame() 
	{
		foreach (GameObject b in buttons)
			b.SetActive (false);
		bash.SetActive(true);
		StartCoroutine (Wait (12.50F));

	}

	public void QuitGame() 
	{
		Application.Quit();
	}

	IEnumerator Wait (float t) {
		yield return new WaitForSeconds (t); 
		SceneManager.LoadScene(levelname);
	}
}
