using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class score : MonoBehaviour {
	public float coins;
	public bool loss = false;
	public Image backdrop;
	// Use this for initialization
	public void lose(){
		if (!loss) {
			if (PlayerPrefs.GetFloat ("highscore") < coins) {
				PlayerPrefs.SetFloat ("highscore", coins);
			}
			loss = true;
			GameObject.FindGameObjectWithTag ("Player").GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter> ().Move (Vector3.zero, false, false);
			GameObject.FindGameObjectWithTag ("Enemy").GetComponent<UnityEngine.AI.NavMeshAgent> ().Stop ();
			GameObject.FindGameObjectWithTag ("Player").GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl> ().enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Text> ().text = coins.ToString ();
		if (loss && backdrop.color.a<1) {
			GameObject audio = GameObject.FindGameObjectWithTag ("Audio");

			foreach (Transform child in audio.transform) {
				child.GetComponent<AudioSource> ().volume -= Time.deltaTime;
			}	

			Color col = backdrop.color;
			col.a += Time.deltaTime*2;
			backdrop.color = col;
		}
		if (loss && Input.GetKeyDown(KeyCode.Escape)) {
			UnityEngine.SceneManagement.SceneManager.LoadScene ("mainMenu");
		}
		if (loss && Input.GetKeyDown(KeyCode.Space)) {
			UnityEngine.SceneManagement.SceneManager.LoadScene ("mainStage");
		}
	}
}
