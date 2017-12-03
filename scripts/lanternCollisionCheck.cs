using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lanternCollisionCheck : MonoBehaviour {
	void OnTriggerEnter(Collider col){
		if (col.tag == "Player") {
			col.GetComponent<visibility> ().lightVisibility = 1;
		}
	}
	void OnTriggerExit(Collider col){
		if (col.tag == "Player") {
			col.GetComponent<visibility> ().lightVisibility = 0;
		}
	}
}
