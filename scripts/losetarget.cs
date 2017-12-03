using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class losetarget : MonoBehaviour {
	void loseTarget(){
		GameObject.FindGameObjectWithTag ("Enemy").GetComponent<routeCalculator> ().playerNotFound ();
	}
}
