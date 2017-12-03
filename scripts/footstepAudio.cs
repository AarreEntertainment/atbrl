using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footstepAudio : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnCollisionEnter (Collision col) {
		
		if (col.collider.name == "Terrain" && !GetComponent<AudioSource> ().isPlaying) {
			GetComponent<AudioSource> ().Play ();
		}
	}

}
