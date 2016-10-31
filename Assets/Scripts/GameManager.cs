using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    public int Ressource = 0;
    public int IndexItem = 0;

    private bool gameEnded;
    private int wave;
    public int monstersLeft;
    private SpawnManager sm;

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
        sm = GetComponent<SpawnManager>();
        gameEnded = false;
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
        monstersLeft = 0;
        wave = 0;
        StartCoroutine(WaveTurn());
	}


	public void checkIfGameOver(Repository repot){
		if (repot.getCurHp() <= 0) {
            gameEnded = true;
			print ("Game Over");
			repot.launchGameOverEffect ();
			player.enabled = false;
		}
	}

	public CameraManager getCamera(){
		return cameraManager;
	}

    IEnumerator WaveTurn() {
        while(!gameEnded) {
            wave++;
            sm.StartNewWave(wave);
            yield return new WaitWhile(() => monstersLeft > 0);
            yield return new WaitForSeconds(5f);
        }
    }
}
