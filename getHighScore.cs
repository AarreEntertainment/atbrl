using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getHighScore : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		GetComponent<UnityEngine.UI.Text> ().text = "Press Space to start.\nHigh Score: " + PlayerPrefs.GetFloat ("highscore").ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			UnityEngine.SceneManagement.SceneManager.LoadScene ("mainStage");
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}
	}
}
