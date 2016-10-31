using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    public int Ressource = 0;
    public int IndexItem = 0;

	private PlayerController player;

	private CameraManager cameraManager;

    void Awake () {
		cameraManager = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<CameraManager>();
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }
	
	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
	}


	public void checkIfGameOver(Repository repot){
		if (repot.getCurHp() <= 0) {
			print ("Game Over");
			repot.launchGameOverEffect ();
			player.enabled = false;
		}
	}

	public CameraManager getCamera(){
		return cameraManager;
	}
}
