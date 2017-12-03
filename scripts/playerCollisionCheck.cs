using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollisionCheck : MonoBehaviour {

	void OnCollisionEnter(Collision col){
		if (col.collider.tag == "Enemy") {
			GameObject.FindGameObjectWithTag ("Score").GetComponent<score> ().lose ();
		}
	}
	
}
