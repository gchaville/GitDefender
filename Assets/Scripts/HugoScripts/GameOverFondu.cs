using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverFondu : MonoBehaviour {

	public CanvasGroup myCG;

     void Update ()
     {
            myCG.alpha += 0.01f;
      }
}
