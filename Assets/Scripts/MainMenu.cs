﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

	public string levelname;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

	public void StartGame() 
	{
		SceneManager.LoadScene(levelname);

	}

	public void QuitGame() 
	{

		Application.Quit();
	}
}
