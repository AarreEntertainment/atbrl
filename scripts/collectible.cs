using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectible : MonoBehaviour {

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player") {
			GameObject.FindGameObjectWithTag ("Score").GetComponent<score> ().coins++;
			GetComponent<SphereCollider> ().enabled = false;
			GetComponent<AudioSource> ().Play ();
			GetComponent<Animator> ().SetTrigger ("destroy");
		}
	}
	void destroy (){
		GameObject.FindGameObjectWithTag ("Enemy").GetComponent<routeCalculator> ().goingToSpawn = true;
		Destroy (transform.gameObject);
	}
}
