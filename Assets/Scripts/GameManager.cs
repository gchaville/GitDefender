using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    public int Ressource = 0;
    public int IndexItem = 0;

	private PlayerController player;

    void Awake () {
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


	public void checkIfGameOver(int depotHp){
		if (depotHp <= 0) {
			player.enabled = false;
		}
	}
}
