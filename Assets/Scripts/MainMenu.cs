using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{


    public Button playButton;
    public Button exitButton;


    // Use this for initialization
    void Start()
    {

        playButton.onClick.AddListener(() =>
        {
            Application.LoadLevel("_SceneYoussef_Level2");

        });

        exitButton.onClick.AddListener(() =>
        {

            Application.Quit();
        });

    }

    // Update is called once per frame
    void Update()
    {

    }
}
