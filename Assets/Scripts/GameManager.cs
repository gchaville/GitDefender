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
    private int highScore;

	public GameObject uiNewWave;

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

        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }


	public void checkIfGameOver(Repository repot){
		if (repot.getCurHp() <= 0) {
            gameEnded = true;
			print ("Game Over");

            if (wave > highScore){
                PlayerPrefs.SetInt("HighScore", wave);
            }

            repot.launchGameOverEffect ();
            player.StopPlayer();
		}
	}

	public CameraManager getCamera(){
		return cameraManager;
	}

    IEnumerator WaveTurn() {
		yield return new WaitForSeconds(2f);
        while(!gameEnded) {
            wave++;
			instantiateUINewWave (wave.ToString (), -1);
            sm.StartNewWave(wave);
            yield return new WaitWhile(() => monstersLeft > 0);
			instantiateUINewWave ("wave over", 0);
            yield return new WaitForSeconds(5f);
        }
    }

	public int getWave(){
		return wave;
	}

	public void instantiateUINewWave(string text, int value){
		GameObject toInstantiate = Instantiate (uiNewWave, transform) as GameObject;
		toInstantiate.GetComponent<UIWave> ().setText (text,value);
	}
}
